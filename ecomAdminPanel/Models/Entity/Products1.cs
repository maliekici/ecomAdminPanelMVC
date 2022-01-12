//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ecomAdminPanel.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

        public partial class Products1
        {

            public Products1()
            {
                this.BrandList = new List<SelectListItem>();
                BrandList.Insert(0, new SelectListItem { Text = "�nce Kategori Se�ilmelidir", Value = "" });
            }

            public int ID { get; set; }
            public int CategoryID { get; set; }
            public int BrandID { get; set; }
            public string ProductName { get; set; }
            public string BarcodeNo { get; set; }
            public decimal PurchasePrice { get; set; }
            public decimal SalePrice { get; set; }
            public Nullable<decimal> Amount { get; set; }
            public int UnitID { get; set; }
            public Nullable<int> KDV { get; set; }
            [DataType(DataType.Date)]
            public System.DateTime Date { get; set; }
            public string Explanation { get; set; }

            public virtual Brands Brands { get; set; }
            public virtual Categories Categories { get; set; }
            public virtual Units Units { get; set; }
            public List<SelectListItem> CategoryList { get; set; }
            public List<SelectListItem> BrandList { get; set; }
            public List<SelectListItem> UnitList { get; set; }

        }
    
}
