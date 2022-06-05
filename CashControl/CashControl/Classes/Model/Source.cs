using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashControl
{
    [Table("source")]
    public class Source: INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Source()
        {
            Operations = new HashSet<Operation>();
        }

        #region Fields

        private string title;

        private double balance;

        private DateTime lastUpdate;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        [Key]
        [Required]
        [MaxLength(36)]
        public string SourceId { get; set; }

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

        public double Balance
        {
            get => balance;
            set
            {
                balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        public DateTime Creation { get; set; }

        public DateTime LastUpdate
        {
            get => lastUpdate;
            set
            {
                lastUpdate = value;
                OnPropertyChanged(nameof(LastUpdate));
            }
        }

        #endregion

        #region Navidation Properties

        public string CurrencyId { get; set; }

        [ForeignKey(nameof(CurrencyId))]
        public virtual Currency Currency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operations { get; set; }

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
