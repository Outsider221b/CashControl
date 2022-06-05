using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashControl
{
    [Table("credit_operation")]
    public class CreditOperation: INotifyPropertyChanged
    {
        #region Fields 
        
        public event PropertyChangedEventHandler PropertyChanged;

        private string title;

        private string description;

        private double moneyCount;

        private bool isProfit;

        private bool isActual;

        #endregion

        #region Properties

        [Key]
        [Required]
        [MaxLength(36)]
        public string CreditOperationId { get; set; }

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

        public double MoneyCount
        {
            get => moneyCount;
            set
            {
                moneyCount = value;
                OnPropertyChanged(nameof(MoneyCount));
            }
        }

        public bool IsProfit
        {
            get => isProfit;
            set
            {
                isProfit = value;
                OnPropertyChanged(nameof(IsProfit));
            }
        }

        public bool IsActual
        {
            get => isActual;
            set
            {
                isActual = value;
                OnPropertyChanged(nameof(IsActual));
            }
        }
        #endregion

        #region Navigation Properties

        public string PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }

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
