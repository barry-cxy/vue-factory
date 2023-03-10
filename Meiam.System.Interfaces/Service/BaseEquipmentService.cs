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
    public class BaseEquipmentService : BaseService<Base_Equipment>, IBaseEquipmentService
    {

        public BaseEquipmentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region CustomInterface 
        /// <summary>
        /// 查询设备（分页）
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<EquipmentVM> QueryEquipPages(EquipmentQueryDto parm)
        {
            var source = Db.Queryable<Base_Equipment, Sys_DataRelation, Base_ProductLine, Sys_DataRelation, Base_ProductProcess, Sys_DataRelation, Base_WorkShop, Sys_DataRelation, Base_Factory>((a, b, c, d, e, f, g, h, j) => new object[] {
                JoinType.Inner,a.ID == b.Form,
                JoinType.Inner,b.To == c.ID,
                JoinType.Inner,c.ID == d.Form,
                JoinType.Inner,d.To == e.ID,
                JoinType.Inner,e.ID == f.Form,
                JoinType.Inner,f.To == g.ID,
                JoinType.Inner,g.ID == h.Form,
                JoinType.Inner,h.To == j.ID,
            })
            .WhereIF(!string.IsNullOrEmpty(parm.QueryText), (a, b, c, d, e, f, g, h, j) => a.EquipNo.Contains(parm.QueryText) || a.EquipName.Contains(parm.QueryText))
            .Select((a, b, c, d, e, f, g, h, j) => new EquipmentVM
            {
                ID = a.ID,
                EquipNo = a.EquipNo,
                EquipName = a.EquipName,
                Remark = a.Remark,
                Enable = a.Enable,
                LineUID = c.ID,
                LineNo = c.LineNo,
                LineName = c.LineName,
                ProcessUID = e.ID,
                ProcessNo = e.ProcessNo,
                ProcessName = e.ProcessName,
                WorkShopUID = g.ID,
                WorkShopNo = g.WorkShopNo,
                WorkShopName = g.WorkShopName,
                FactoryUID = j.ID,
                FactoryNo = j.FactoryNo,
                FactoryName = j.FactoryName,
                CreateTime = a.CreateTime,
                UpdateTime = a.UpdateTime,
                CreateID = a.CreateID,
                CreateName = a.CreateName,
                UpdateID = a.UpdateID,
                UpdateName = a.UpdateName
            })
            .MergeTable();

            return source.ToPage(new PageParm { PageIndex = parm.PageIndex, PageSize = parm.PageSize, OrderBy = parm.OrderBy, Sort = parm.Sort });
        }

        /// <summary>
        /// 根据ID查询设备
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EquipmentVM GetEquip(string id)
        {
            var source = Db.Queryable<Base_Equipment, Sys_DataRelation, Base_ProductLine, Sys_DataRelation, Base_ProductProcess, Sys_DataRelation, Base_WorkShop, Sys_DataRelation, Base_Factory>((a, b, c, d, e, f, g, h, j) => new object[] {
                JoinType.Inner,a.ID == b.Form,
                JoinType.Inner,b.To == c.ID,
                JoinType.Inner,c.ID == d.Form,
                JoinType.Inner,d.To == e.ID,
                JoinType.Inner,e.ID == f.Form,
                JoinType.Inner,f.To == g.ID,
                JoinType.Inner,g.ID == h.Form,
                JoinType.Inner,h.To == j.ID,
            }).Where((a, b, c, d, e, f, g, h, j) => a.ID == id)
            .Select((a, b, c, d, e, f, g, h, j) => new EquipmentVM
            {
                ID = a.ID,
                EquipNo = a.EquipNo,
                EquipName = a.EquipName,
                Remark = a.Remark,
                Enable = a.Enable,
                LineUID = c.ID,
                LineNo = c.LineNo,
                LineName = c.LineName,
                ProcessUID = e.ID,
                ProcessNo = e.ProcessNo,
                ProcessName = e.ProcessName,
                WorkShopUID = g.ID,
                WorkShopNo = g.WorkShopNo,
                WorkShopName = g.WorkShopName,
                FactoryUID = j.ID,
                FactoryNo = j.FactoryNo,
                FactoryName = j.FactoryName,
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
        /// 根据编码查询设备
        /// </summary>
        /// <param name="EquipNo"></param>
        /// <returns></returns>
        public EquipmentVM GetEquipByNo(string equipNo)
        {
            var source = Db.Queryable<Base_Equipment, Sys_DataRelation, Base_ProductLine, Sys_DataRelation, Base_ProductProcess, Sys_DataRelation, Base_WorkShop, Sys_DataRelation, Base_Factory>((a, b, c, d, e, f, g, h, j) => new object[] {
                JoinType.Inner,a.ID == b.Form,
                JoinType.Inner,b.To == c.ID,
                JoinType.Inner,c.ID == d.Form,
                JoinType.Inner,d.To == e.ID,
                JoinType.Inner,e.ID == f.Form,
                JoinType.Inner,f.To == g.ID,
                JoinType.Inner,g.ID == h.Form,
                JoinType.Inner,h.To == j.ID,
            }).Where((a, b, c, d, e, f, g, h, j) => a.EquipNo == equipNo)
            .Select((a, b, c, d, e, f, g, h, j) => new EquipmentVM
            {
                ID = a.ID,
                EquipNo = a.EquipNo,
                EquipName = a.EquipName,
                Remark = a.Remark,
                Enable = a.Enable,
                LineUID = c.ID,
                LineNo = c.LineNo,
                LineName = c.LineName,
                ProcessUID = e.ID,
                ProcessNo = e.ProcessNo,
                ProcessName = e.ProcessName,
                WorkShopUID = g.ID,
                WorkShopNo = g.WorkShopNo,
                WorkShopName = g.WorkShopName,
                FactoryUID = j.ID,
                FactoryNo = j.FactoryNo,
                FactoryName = j.FactoryName,
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
        /// 根据产线编码查询设备定义
        /// </summary>
        /// <param name="lineNo"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public List<EquipmentVM> GetEquipByLine(string lineNo, bool? enable = null)
        {
            var source = Db.Queryable<Base_Equipment, Sys_DataRelation, Base_ProductLine, Sys_DataRelation, Base_ProductProcess, Sys_DataRelation, Base_WorkShop, Sys_DataRelation, Base_Factory>((a, b, c, d, e, f, g, h, j) => new object[] {
                JoinType.Inner,a.ID == b.Form,
                JoinType.Inner,b.To == c.ID,
                JoinType.Inner,c.ID == d.Form,
                JoinType.Inner,d.To == e.ID,
                JoinType.Inner,e.ID == f.Form,
                JoinType.Inner,f.To == g.ID,
                JoinType.Inner,g.ID == h.Form,
                JoinType.Inner,h.To == j.ID,
            }).Where((a, b, c, d, e, f, g, h, j) => c.LineNo == lineNo)
            .WhereIF(enable != null, (a, b, c, d, e, f, g, h, j) => a.Enable == enable)
            .Select((a, b, c, d, e, f, g, h, j) => new EquipmentVM
            {
                ID = a.ID,
                EquipNo = a.EquipNo,
                EquipName = a.EquipName,
                Remark = a.Remark,
                Enable = a.Enable,
                LineUID = c.ID,
                LineNo = c.LineNo,
                LineName = c.LineName,
                ProcessUID = e.ID,
                ProcessNo = e.ProcessNo,
                ProcessName = e.ProcessName,
                WorkShopUID = g.ID,
                WorkShopNo = g.WorkShopNo,
                WorkShopName = g.WorkShopName,
                FactoryUID = j.ID,
                FactoryNo = j.FactoryNo,
                FactoryName = j.FactoryName,
                CreateTime = a.CreateTime,
                UpdateTime = a.UpdateTime,
                CreateID = a.CreateID,
                CreateName = a.CreateName,
                UpdateID = a.UpdateID,
                UpdateName = a.UpdateName
            });

            return source.ToList();
        }

        /// <summary>
        /// 查询所有设备
        /// </summary>
        /// <returns></returns>
        public List<EquipmentVM> GetAllEquip(bool? enable = null)
        {
            var source = Db.Queryable<Base_Equipment, Sys_DataRelation, Base_ProductLine, Sys_DataRelation, Base_ProductProcess, Sys_DataRelation, Base_WorkShop, Sys_DataRelation, Base_Factory>((a, b, c, d, e, f, g, h, j) => new object[] {
                JoinType.Inner,a.ID == b.Form,
                JoinType.Inner,b.To == c.ID,
                JoinType.Inner,c.ID == d.Form,
                JoinType.Inner,d.To == e.ID,
                JoinType.Inner,e.ID == f.Form,
                JoinType.Inner,f.To == g.ID,
                JoinType.Inner,g.ID == h.Form,
                JoinType.Inner,h.To == j.ID,
            })
            .WhereIF(enable != null, (a, b, c, d, e, f, g, h, j) => a.Enable == enable)
            .Select((a, b, c, d, e, f, g, h, j) => new EquipmentVM
            {
                ID = a.ID,
                EquipNo = a.EquipNo,
                EquipName = a.EquipName,
                Remark = a.Remark,
                Enable = a.Enable,
                LineUID = c.ID,
                LineNo = c.LineNo,
                LineName = c.LineName,
                ProcessUID = e.ID,
                ProcessNo = e.ProcessNo,
                ProcessName = e.ProcessName,
                WorkShopUID = g.ID,
                WorkShopNo = g.WorkShopNo,
                WorkShopName = g.WorkShopName,
                FactoryUID = j.ID,
                FactoryNo = j.FactoryNo,
                FactoryName = j.FactoryName,
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
        /// 查询同生产线下是否存在相同设备编码
        /// </summary>
        /// <param name="equipNo"></param>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public bool Any(string Id, string equipNo, string lineId)
        {
            return Db.Queryable<Base_Equipment, Sys_DataRelation>((a, b) => new object[] {
                JoinType.Inner,a.ID == b.Form
            })
            .Any((a, b) => a.ID != Id && a.EquipNo == equipNo && b.To == lineId && b.Type == DataRelationType.Equipment_To_Line.ToString());
        }
        #endregion

    }
}
