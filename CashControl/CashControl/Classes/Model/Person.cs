using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashControl
{
    //Complete
    [Table("person")]
    public class Person: INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            CreditOperations = new HashSet<CreditOperation>();
        }

        #region Fields

        private string fullName;
        private string description;
        private DateTime lastUpdate;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        [Key]
        [Required]
        [MaxLength(36)]
        public string PersonId { get; set; }

        [Required]
        [MaxLength(80)]
        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged(nameof(FullName));
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

        #region Navigation Properties;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditOperation> CreditOperations { get; set; }

        #endregion

        #region Voids

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        #region Not Mapped Properties

        [NotMapped]
        public string GetCreationString { get => Creation.ToString("g"); }

        [NotMapped]
        public string GetLastUpdateString { get => LastUpdate.ToString("g"); }

        #endregion
    }
}
