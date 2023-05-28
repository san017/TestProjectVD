namespace Query
{
    /// <summary>
    /// Тело SQL - запроса.
    /// </summary>
    public static class SqlQueryConstant
    {
        /// <summary>
        /// Сумма всех заключенных договоров за текущий год.
        /// </summary>
        public const string AmountContractInCurrentYear = "SELECT SUM(c.Amount) " +
                                                     "FROM[dbo].[Contract] c " +
                                                     "WHERE DATEPART(YY, c.DateSigning) = DATEPART(YY, GETDATE())";

        /// <summary>
        /// Сумма заключенных договоров по каждому контрагенту из России.
        /// </summary>
        public const string AmountContractForEachContractor = "SELECT j.[CompanyName]," +
                                                                      "ISNULL(SUM(c.[Amount]),0) AS SumAmount " +
                                                               "FROM [dbo].[Contract] AS c " +
                                                               "RIGHT JOIN [dbo].[JuridicalPerson] AS j " +
                                                                           "ON c.[ContractorId] = j.[JuridicalPersonID] " +
                                                               "WHERE j.[Country] = 'Россия' " +
                                                               "GROUP BY  j.[CompanyName] ";

        /// <summary>
        /// Список e-mail уполномоченных лиц заключивших договора за последний 30 дней, на сумму больше 40000.
        /// </summary>
        public const string ListMailIndividualPerson = "SELECT * " +
                                                       "FROM[dbo].[IndividualPerson] i " +
                                                       "JOIN[dbo].[Contract] c " +
                                                             "ON c.[AuthorisedPersonId] = i.[PersonId] " +
                                                       "WHERE c.[DateSigning] > GETDATE() - 30 " +
                                                                                "AND c.[Amount] > 40000";

        /// <summary>
        /// Список физ.лиц, у которых есть действующие договора по компаниям, расположенных в городе Москва.
        /// </summary>
        public const string InfoIndividualPersonHaveActiveContract = "SELECT  * " +
                                                                     "FROM[dbo].[IndividualPerson] i " +
                                                                     "JOIN[dbo].[Contract] c " +
                                                                          "ON c.[AuthorisedPersonId] = i.[PersonId] " +
                                                                     "JOIN[dbo].[JuridicalPerson] j " +
                                                                          "ON j.[JuridicalPersonID] = c.[ContractorId] " +
                                                                     "WHERE c.[Status] = 'Действующий' " +
                                                                                     "AND j.[City] = 'Москва'";
    }
}
