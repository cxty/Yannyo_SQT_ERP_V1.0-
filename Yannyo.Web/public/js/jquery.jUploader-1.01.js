/*
* jQuery jUploader 1.01
* http://www.kudystudio.com
* Author: kudy chen (kudychen@gmail.com)
* 
* Copyright 2012, kudy studio
* Dual licensed under the MIT or LGPL Version 3 licenses.
* 
* Last Modified: 2012-09-10
*/

(function ($) {
    window.jUploader = $.jUploader = function (options) {
        options = $.extend({}, $.jUploader.defaults, options);
        options.id = $.jUploader.createId();
        options.uploading = false;

        var initButton = function () {
            options.button = (typeof options.button == 'string') ? $('#' + options.button) : $(options.button);
            options.button.css({
                cursor: 'pointer',
                position: 'relative',
                overflow: 'hidden',
                // Make sure browse button is in the right side in IE
                direction: 'ltr'
            })
            .addClass('jUploader-button')
            .bind('mouseover', function () {
                $(this).addClass('jUploader-button-hover');
            })
            .bind('mouseout', function () {
                $(this).removeClass('jUploader-button-hover');
            })
            .children('span').text(options.messages.upload);

            if (options.cancelable) {
                options.button.bind('click', cancel)
            }

            options.button.append(createInput());

            return options.button;
        };

        var createIframe = function () {
            var id = 'jUploaderIframe' + options.id;
            var iframe = $('<iframe id="' + id + '" name="' + id + '" src="javascript:false;" style="display:none"></iframe>').bind('load', complete);

            return iframe;
        };

        var createForm = function () {
            var id = 'jUploaderForm' + options.id;
            var form = $('<form id="' + id + '" name="' + id + '" action="' + options.action + '" target="jUploaderIframe' + options.id + '" method="post" enctype="multipart/form-data" style="display:none"></form>');

            return form;
        };

        var createInput = function () {
            // onchange="this.blur();"
            // is to aotu-rasie input file onchange event in IE(it is a bug in IE)
            var input = $('<input type="file" onchange="this.blur();" />');
            input
            .attr("id", 'jUploader-file' + options.id)
            .attr("name", 'jUploaderFile')
            .css({
                position: 'absolute',
                right: 0,
                top: 0,
                margin: 0,
                opacity: 0,
                padding: 0,
                fontFamily: 'Arial',
                fontSize: '118px',
                verticalAlign: 'baseline',
                cursor: 'pointer'
            })
            .bind('change', function () {
                options.fileName = getFileName(this);
                if (validateFile(this)) {
                    upload();
                }
            });

            // IE and Opera, unfortunately have 2 tab stops on file input
            // which is unacceptable in our case, disable keyboard access
            if (window.attachEvent) {
                // it is IE or Opera
                input.attr('tabIndex', "-1");
            }

            return input;
        };

        var validateFile = function (file) {
            var name = getFileName(file);

            if (!isAllowedExtension(name)) {
                showMessage('invalidExtension', name);
                return false;
            } else if (name == '') {
                showMessage('emptyFile', name);
                return false;
            }

            return true;
        };
        var getFileName = function (file) {
            // get input value and remove path to normalize
            return file.value.replace(/.*(\/|\\)/, "");
        };
        var formatFileName = function (name) {
            if (name.length > 33) {
                name = name.slice(0, 19) + '...' + name.slice(-13);
            }
            return name;
        };
        var isAllowedExtension = function (fileName) {
            var ext = (-1 !== fileName.indexOf('.')) ? fileName.replace(/.*[.]/, '').toLowerCase() : '';
            if (!options.allowedExtensions.length) { return true; }
            for (var i = 0; i < options.allowedExtensions.length; i++) {
                if (options.allowedExtensions[i].toLowerCase() == ext) { return true; }
            }
            return false;
        };
        var showMessage = function (type, fileName) {
            var message = options.messages[type]

            .replace('{file}', formatFileName(fileName))
            .replace('{extensions}', options.allowedExtensions.join(', '));

            options.showMessage(message);
        };
        var log = function (message) {
            if (options.debug && window.console) console.log('[jUploader] ' + message);
        };

        var upload = function () {
            options.uploading = true;
            options.onUpload(options.fileName);
            // prepare iframe and form for uploading
            $(document.body).append(createIframe()).append(createForm());

            // move the input to the target form
            $('#jUploader-file' + options.id)
            .attr('id', 'jUploader-file-uploading' + options.id)
            .appendTo('#jUploaderForm' + options.id);

            // create new input, and hide it for cancel event
            options.button.append(createInput().hide());
            if (options.cancelable) {
                options.button.children('span').text(options.messages.cancel);
            }

            // submit it
            $('#jUploaderForm' + options.id).get(0).submit();
        };

        var cancel = function () {
            if (options.uploading) {
                options.uploading = false;
                options.onCancel(options.fileName);
                options.button.children('span').text(options.messages.upload);
                $('#jUploaderForm' + options.id).remove();
                $('#jUploaderIframe' + options.id).attr('src', 'javascript:false;').remove();
                $('#jUploader-file' + options.id).show();
            }
        };

        var complete = function () {
            var iframe = $('#jUploaderIframe' + options.id).get(0);
            // when we remove iframe from dom
            // the request stops, but in IE load
            // event fires
            if (!iframe.parentNode) {
                return;
            }

            // fixing Opera 10.53
            if ((iframe.contentDocument &&
                iframe.contentDocument.body &&
                iframe.contentDocument.body.innerHTML == "false")
                || (iframe.contentWindow.document &&
                iframe.contentWindow.document.body &&
                iframe.contentWindow.document.body.innerHTML == "false")) {
                // In Opera event is fired second time
                // when body.innerHTML changed from false
                // to server response approx. after 1 sec
                // when we upload file with iframe
                return;
            }

            // iframe.contentWindow.document - for IE<7
            var doc = iframe.contentDocument ? iframe.contentDocument : iframe.contentWindow.document;
            var response;

            //var innerHtml = doc.body.innerText;
            var innerHtml = $(doc.body).text();
            log("innerHTML = " + innerHtml);

            // fix for chrome
            if (innerHtml == '') {
                return;
            }

            options.uploading = false;
            $('#jUploader-file' + options.id).show();
            options.button.children('span').text(options.messages.upload);

            try {
                var json = innerHtml.replace(/<pre.*>(.*)<\/pre>/g, '$1');
                response = eval("(" + json + ")");
            } catch (e) {
                response = {};
                //throw e;
            }

            // timeout added to fix busy state in FF3.6
            setTimeout(function () {
                $('#jUploaderForm' + options.id).remove();
                $('#jUploaderIframe' + options.id).remove();
            }, 10);

            options.onComplete(options.fileName, response);
        };

        // remind user of uploading
        $(window).bind('beforeunload', function (e) {
            if (!options.uploading)
                return;

            var e = e || window.event;
            // for ie, ff
            e.returnValue = options.messages.onLeave;
            // for webkit
            return options.messages.onLeave;
        });

        return initButton();
    };

    $.jUploader.version = 1.0;

    $.jUploader.defaults = {
        button: null,
        action: 'upload.aspx',
        allowedExtensions: [],
        cancelable: true,
        // events
        onUpload: function (fileName) { },
        onComplete: function (fileName, response) { },
        onCancel: function (fileName) { },
        // messages
        messages: {
            upload: 'Upload',
            cancel: 'Cancel',
            emptyFile: "{file} is empty, please select files again without it.",
            invalidExtension: "{file} has invalid extension. Only {extensions} are allowed.",
            onLeave: "The files are being uploaded, if you leave now the upload will be cancelled."
        },
        showMessage: function (message) {
            alert(message);
        },
        debug: false
    };

    $.jUploader.setDefaults = function (defaults) {
        $.jUploader.defaults = $.extend({}, $.jUploader.defaults, defaults);
    };

    $.jUploader.createId = (function () {
        var id = 0;
        return function () { return ++id; };
    })();
})(jQuery);
