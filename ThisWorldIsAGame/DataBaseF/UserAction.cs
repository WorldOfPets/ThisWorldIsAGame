//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThisWorldIsAGame.DataBaseF
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserAction
    {
        public int Id { get; set; }
        public Nullable<int> IdUser { get; set; }
        public Nullable<int> IdAction { get; set; }
        public string Parameter { get; set; }
    
        public virtual Action Action { get; set; }
        public virtual UserG UserG { get; set; }
    }
}
