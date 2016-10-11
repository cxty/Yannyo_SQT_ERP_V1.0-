using System;
using System.Collections.Generic;
using Top.Api.Response;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.taobaoke.virtualcard.get
    /// </summary>
    public class TaobaokeVirtualcardGetRequest : ITopRequest<TaobaokeVirtualcardGetResponse>
    {
        /// <summary>
        /// 电话卡地区目前只有如下地区支持:  浙江      上海      北京      广东      江苏      山东      福建      辽宁      河南      四川      湖北      天津      湖南      河北      重庆      云南      新疆      西藏      青海      宁夏      内蒙      江西      吉林      黑龙江      海南      贵州      广西      甘肃      安徽      陕西      山西
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 电话卡或游戏点卡标记.  电话卡：phoneCard，游戏卡：gameCard    注意:如果是电话卡查询,则 area,operator,price,card_type都是必须的参数.   如果是游戏卡查询,则game_name,price,card_type是必须参数
        /// </summary>
        public string BizType { get; set; }

        /// <summary>
        /// 电话充值卡类型.  卖家代充：autoship，自动发货：autopost，10分钟代充：10minship
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// 需返回的字段列表.可选值:num_iid,title,nick,pic_url,price,click_url,commission,ommission_rate,commission_num,commission_volume,shop_click_url,seller_credit_score,item_location,volume ;字段之间用","分隔
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 游戏名,目前只支持如下游戏:  魔兽世界      永恒之塔      奇迹世界      征途      热血传奇      传奇世界      梦幻西游      大话西游      大唐豪侠      天龙八部      完美世界      魔域      诛仙      热血江湖      问道      劲舞团      完美世界国际版      剑侠世界      武林外传      剑情网络版      剑侠情缘      封神榜      QQ幻想      泡泡堂      冒险岛      水浒Q传      彩虹岛      街头篮球      跑跑卡丁车      三国群英传      惊天动地      超级舞者      梦幻国度      天堂      风云      卓越之剑      华夏      联众世界      浩方      春秋Q传      刀剑英雄      新英雄年代      信长之野望      热舞派对      赤壁      大话西游外传      SD敢达      穿越火线      QQ自由幻想      QQ三国      QQ华夏      传奇外传      封神榜      地下城与勇士
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// 淘宝用户昵称，注：指的是淘宝的会员登录名.如果昵称错误,那么客户就收不到佣金.每个淘宝昵称都对应于一个pid，在这里输入要结算佣金的淘宝昵称，当推广的商品成功后，佣金会打入此输入的淘宝昵称的账户。具体的信息可以登入阿里妈妈的网站查看
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 电话卡运营商.  1:移动 2:联通 3:电信
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 自定义输入串.格式:英文和数字组成;长度不能大于12个字符,区分不同的推广渠道,如:bbs,表示bbs为推广渠道;blog,表示blog为推广渠道.
        /// </summary>
        public string OuterCode { get; set; }

        /// <summary>
        /// 结果页数.1~99
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页返回结果数.最大每页40
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 淘客id
        /// </summary>
        public string Pid { get; set; }

        /// <summary>
        /// 充值卡面值.目前只支持如下面值:    1,          10,           20,           30,           50,           100,          200,          300,          500,           1000
        /// </summary>
        public string Price { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.taobaoke.virtualcard.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("area", this.Area);
            parameters.Add("biz_type", this.BizType);
            parameters.Add("card_type", this.CardType);
            parameters.Add("fields", this.Fields);
            parameters.Add("game_name", this.GameName);
            parameters.Add("nick", this.Nick);
            parameters.Add("operator", this.Operator);
            parameters.Add("outer_code", this.OuterCode);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("pid", this.Pid);
            parameters.Add("price", this.Price);
            return parameters;
        }

        #endregion
    }
}
