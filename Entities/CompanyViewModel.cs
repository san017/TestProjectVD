namespace Entities
{
    /// <summary>
    /// Представление для контрагентов и суммы их контрактов.
    /// </summary>
    public class CompanyViewModel
    {
        /// <summary>
        /// Наименнование контрагента.
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Сумма контрактов.
        /// </summary>
        public double SumAmount { get; set; }
    }
}
