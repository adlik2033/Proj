//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Проект.windows
{
    using System;
    using System.Collections.Generic;
    
    public partial class Farms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Farms()
        {
            this.Transactions = new HashSet<Transactions>();
        }
    
        public int id { get; set; }
        public string locationWH { get; set; }
        public Nullable<int> Capacity { get; set; }
        public Nullable<int> AnimalsID { get; set; }
        public Nullable<int> EmployesID { get; set; }
    
        public virtual Animals Animals { get; set; }
        public virtual Employes Employes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
