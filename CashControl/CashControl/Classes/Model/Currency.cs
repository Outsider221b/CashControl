 using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashControl
{
    [Table("currency")]
    public class Currency: INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Currency()
        {
            Sources = new HashSet<Source>();
        }

        #region Fields

        private string title;

        private string description;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        [Key]
        [Required]
        [MaxLength(36)]
        public string CurrencyId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title 
        { 
            get => title; 
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        [MaxLength(200)]
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        #endregion

        #region Navigation Properties

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Source> Sources { get; set; }

        #endregion

        #region Voids

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }
}
