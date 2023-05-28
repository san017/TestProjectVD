using Entities;
using Query;
using Serializer;
using System;
using System.Configuration;
using System.Linq;

namespace TestProjectVD
{
    public static class ConsoleDemo
    {
        private static readonly int _age = 60;
        private static readonly string _statusContract = "Расторгнут";

        public static void ConsoleMenu()
        {
            Console.WriteLine("\nДоступные команды:");
            Console.WriteLine("1:Вывести сумму всех заключенных договоров за текущий год.\n" +
                "2:Вывести сумму заключенных договоров по каждому контрагенту из России.\n" +
                "3:Вывести список e-mail уполномоченных лиц, заключивших договора за последние 30  дней, на сумму больше 40000.\n" +
                "4:Изменить статус договора на 'Расторгнут' для физических лиц, у которых есть " +
                "действующий договор, и возраст которых старше 60 лет включительно.");
            Console.Write("Введите число желаемого пункта: ");
        }
        public static void PrintAmountContract()
        {
            foreach (var item in SqlQuery.SelectQuery<double>(SqlQueryConstant.AmountContractInCurrentYear))
            {
                Console.WriteLine($"Cумма заключенных контактов за текущий год: {item}");
            }
        }

        public static void PrintAmountContractForEachContractor()
        {
            foreach (var item in SqlQuery.SelectQuery<CompanyViewModel>(SqlQueryConstant.AmountContractForEachContractor))
            {
                Console.WriteLine($"Контрагент из России: '{item.CompanyName}'\nСумма заключенных договоров: {item.SumAmount}\n");

            }
        }

        public static void PrintListMailInvidualPerson()
        {
            foreach (var item in SqlQuery.SelectQuery<IndividualPerson>(SqlQueryConstant.ListMailIndividualPerson))
            {
                Console.WriteLine($"Почта уполномоченного лица: {item.Mail}");
            }
        }

        public static void PrintChangeStatusContract()
        {
            var countChangeString = SqlQuery.UpdateStatusContract(_age, _statusContract);
            Console.WriteLine("Кол-во изменённых записей - " + SqlQuery.UpdateStatusContract(_age, _statusContract));
        }

        public static void JsonReportIndividualPerson()
        {
            var individualPerson = SqlQuery.SelectQuery<IndividualPerson>(SqlQueryConstant.InfoIndividualPersonHaveActiveContract)
            .Select(c => c = new IndividualPerson()
            {
                Name = c.Name,
                SurName = c.SurName,
                Patronymic = c.Patronymic,
                Mail = c.Mail,
                NumberPhone = c.NumberPhone,
                DateBirthday = c.DateBirthday
            });

            Serialize.WriteJsonFile(individualPerson, ConfigurationManager.AppSettings["fileName"]);

            Console.WriteLine("Отчёт сформирован");
        }
    }
}
