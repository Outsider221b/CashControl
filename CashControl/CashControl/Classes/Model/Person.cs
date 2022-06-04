using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashControl
{
    [Table("person")]
    public class Person: INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            CreditOperations = new HashSet<CreditOperation>();
        }

        private string fullName;
        private string description;
        private DateTime lastUpdate;

        [Key]
        [Required]
        [MaxLength(36)]
        public string Id { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditOperation> CreditOperations { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
