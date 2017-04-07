using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TensunCloud.Controllers;

namespace TensunCloud.Data
{
    // 以下枚举类型在升级版本中改为关联表，以提高扩展性。
    public enum TSDept
    {
        技术部, 市场部, 行政部
    }
    public enum TSRegion
    {
        东区, 西区, 西南区, 东南区, 北区
    }
    public enum Province
    {
        北京市, 天津市, 河北省, 山西省, 内蒙古自治区, 辽宁省, 吉林省, 黑龙江省, 上海市, 江苏省, 浙江省, 安徽省, 福建省, 江西省, 山东省, 河南省, 湖北省, 湖南省, 广东省, 广西壮族自治区, 海南省, 四川省, 贵州省, 云南省, 重庆市, 西藏自治区, 陕西省, 甘肃省, 青海省, 宁夏回族自治区, 新疆维吾尔自治区, 香港特别行政区, 澳门特别行政区, 台湾省
    }
    public enum TSTitle
    {
        员工, 部门经理, 大区经理, 副总经理, 总经理
    }
    public enum ProjectType
    {
        产品销售, 系统集成, 售后服务
    }
    public enum ProjectStatus
    {
        筹备, 进行中, 维保期
    }
    public enum ProductCatalog
    {
        A类产品, B类产品, C类产品, D类产品, E类产品
    }
    public enum TeamMemberType
    {
        项目经理,售前技术,实施工程师,销售经理
    }
    public enum PartyRelationType
    {
        业主,甲方,乙方,丙方,监理方,供应商,外包方,竞争对手,共同施工方
    }
    public enum PartyType
    {
        业主,设计院,政府机关,供应商,集成商,竞争对手
    }

    //定义用户管理弹出窗口大小
    public enum ModalSize
    {
        Small,
        Large,
        Medium
    }
    public class EnumData
    {
    }
}
