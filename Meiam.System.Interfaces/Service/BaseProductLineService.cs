//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
//     author MEIAM
// </auto-generated>
//------------------------------------------------------------------------------
using Meiam.System.Model;
using Meiam.System.Model.Dto;
using Meiam.System.Model.View;
using System.Collections.Generic;
using System.Threading.Tasks;
using SqlSugar;
using System.Linq;
using System;

namespace Meiam.System.Interfaces
{
    public class BaseProductLineService : BaseService<Base_ProductLine>, IBaseProductLineService
    {

        public BaseProductLineService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region CustomInterface 
        /// <summary>
        /// 查询产线（分页）
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ProductLineVM> QueryLinePages(ProductLineQueryDto parm)
        {
            var source = Db.Queryable<Base_ProductLine, Sys_DataRelation, Base_ProductProcess, Sys_DataRelation, Base_WorkShop, Sys_DataRelation, Base_Factory>((a, b, c, d, e, f, g) => new object[] {
                JoinType.Inner,a.ID == b.Form,
                JoinType.Inner,b.To == c.ID,
                JoinType.Inner,c.ID == d.Form,
                JoinType.Inner,d.To == e.ID,
                JoinType.Inner,e.ID == f.Form,
                JoinType.Inner,f.To == g.ID
            })
            .WhereIF(!string.IsNullOrEmpty(parm.QueryText), (a, b, c, d, e, f, g) => a.LineNo.Contains(parm.QueryText) || a.LineName.Contains(parm.QueryText))
            .Select((a, b, c, d, e, f, g) => new ProductLineVM
            {
                ID = a.ID,
                LineNo = a.LineNo,
                LineName = a.LineName,
                Remark = a.Remark,
                Enable = a.Enable,
                ProcessUID = c.ID,
                ProcessNo = c.ProcessNo,
                ProcessName = c.ProcessName,
                WorkShopUID = e.ID,
                WorkShopNo = e.WorkShopNo,
                WorkShopName = e.WorkShopName,
                FactoryUID = g.ID,
                FactoryNo = g.FactoryNo,
                FactoryName = g.FactoryName,
                CreateTime = a.CreateTime,
                UpdateTime = a.UpdateTime,
                CreateID = a.CreateID,
                CreateName = a.CreateName,
                UpdateID = a.UpdateID,
                UpdateName = a.UpdateName
            }).MergeTable();

            return source.ToPage(new PageParm { PageIndex = parm.PageIndex, PageSize = parm.PageSize, OrderBy = parm.OrderBy, Sort = parm.Sort });
        }

        /// <summary>
        /// 根据ID查询产线
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductLineVM GetLine(string id)
        {
            var source = Db.Queryable<Base_ProductLine, Sys_DataRelation, Base_ProductProcess, Sys_DataRelation, Base_WorkShop, Sys_DataRelation, Base_Factory>((a, b, c, d, e, f, g) => new object[] {
                JoinType.Inner,a.ID == b.Form,
                JoinType.Inner,b.To == c.ID,
                JoinType.Inner,c.ID == d.Form,
                JoinType.Inner,d.To == e.ID,
                JoinType.Inner,e.ID == f.Form,
                JoinType.Inner,f.To == g.ID
            }).Where((a, b, c, d, e, f, g) => a.ID == id)
            .Select((a, b, c, d, e, f, g) => new ProductLineVM
            {
                ID = a.ID,
                LineNo = a.LineNo,
                LineName = a.LineName,
                Remark = a.Remark,
                Enable = a.Enable,
                ProcessUID = c.ID,
                ProcessNo = c.ProcessNo,
                ProcessName = c.ProcessName,
                WorkShopUID = e.ID,
                WorkShopNo = e.WorkShopNo,
                WorkShopName = e.WorkShopName,
                FactoryUID = g.ID,
                FactoryNo = g.FactoryNo,
                FactoryName = g.FactoryName,
                CreateTime = a.CreateTime,
                UpdateTime = a.UpdateTime,
                CreateID = a.CreateID,
                CreateName = a.CreateName,
                UpdateID = a.UpdateID,
                UpdateName = a.UpdateName
            }).MergeTable();

            return source.First();
        }

        /// <summary>
        /// 查询所有产线
        /// </summary>
        /// <returns></returns>
        public List<ProductLineVM> GetAllLine(bool? enable = null)
        {
            var source = Db.Queryable<Base_ProductLine, Sys_DataRelation, Base_ProductProcess, Sys_DataRelation, Base_WorkShop, Sys_DataRelation, Base_Factory>((a, b, c, d, e, f, g) => new object[] {
                JoinType.Inner,a.ID == b.Form,
                JoinType.Inner,b.To == c.ID,
                JoinType.Inner,c.ID == d.Form,
                JoinType.Inner,d.To == e.ID,
                JoinType.Inner,e.ID == f.Form,
                JoinType.Inner,f.To == g.ID
            })
            .WhereIF(enable != null, (a, b, c, d, e, f, g) => a.Enable == enable)
            .Select((a, b, c, d, e, f, g) => new ProductLineVM
            {
                ID = a.ID,
                LineNo = a.LineNo,
                LineName = a.LineName,
                Remark = a.Remark,
                Enable = a.Enable,
                ProcessUID = c.ID,
                ProcessNo = c.ProcessNo,
                ProcessName = c.ProcessName,
                WorkShopUID = e.ID,
                WorkShopNo = e.WorkShopNo,
                WorkShopName = e.WorkShopName,
                FactoryUID = g.ID,
                FactoryNo = g.FactoryNo,
                FactoryName = g.FactoryName,
                CreateTime = a.CreateTime,
                UpdateTime = a.UpdateTime,
                CreateID = a.CreateID,
                CreateName = a.CreateName,
                UpdateID = a.UpdateID,
                UpdateName = a.UpdateName
            }).MergeTable().OrderBy(m => m.LineNo);

            return source.ToList();
        }

        /// <summary>
        /// 查询同工序下是否存在相同生产线编码
        /// </summary>
        /// <param name="lineNo"></param>
        /// <param name="processId"></param>
        /// <returns></returns>
        public bool Any(string Id, string lineNo, string processId)
        {
            return Db.Queryable<Base_ProductLine, Sys_DataRelation>((a, b) => new object[] {
                JoinType.Inner,a.ID == b.Form
            })
            .Any((a, b) => a.ID != Id && a.LineNo == lineNo && b.To == processId && b.Type == DataRelationType.Line_To_Process.ToString());
        }
        #endregion

    }
}
