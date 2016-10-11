function CostDetails() {
    this.PageForm = null;
    this.Cost_tree = '';
}
CostDetails.prototype.Checked = function () {
    if (this.Cost_tree) {
        var tArray = this.Cost_tree.split(',');
        for (var i = 0; i < tArray.length; i++) {
            if (tArray[i]) {
                $("#tTree").jstree('check_node', $('#t_' + tArray[i]));
            }
        }
        tArray = null;
    }
}

