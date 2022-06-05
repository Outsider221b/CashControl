using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashControl
{
    [Table("operation")]
    public class Operation: INotifyPropertyChanged
    {
        #region Fields

        private double modeyCount;

        private bool isProfit;

        private string description;

        private DateTime lastUpdate;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        [Required]
        [MaxLength(36)]
        [Key]
        public string OperationId { get; set; }

        public double MoneyCount 
        {
            get => modeyCount;
            set
            {
                modeyCount = value;
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

        #region Navigation Properties

        public string SourceId { get; set; }

        [ForeignKey(nameof(SourceId))]
        public virtual Source Source { get; set; }

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
