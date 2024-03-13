using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfAssistants
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Список всех преступников.");
            List<Criminal> criminals = new List<Criminal>()
             {
                new Criminal("Иванов", "Петр", "Иванович", false, 175, 80, "Русский"),
                new Criminal("Петров", "Иван", "Петрович", true, 180, 85, "Русский"),
                new Criminal("Сидоров", "Алексей", "Владимирович", false, 170, 75, "Русский"),
                new Criminal("Козлов", "Дмитрий", "Александрович", false, 185, 90, "Русский"),
                new Criminal("Николаев", "Сергей", "Павлович", true, 165, 70, "Русский"),
                new Criminal("Васильев", "Андрей", "Сергеевич", false, 172, 78, "Русский"),
                new Criminal("Попов", "Александр", "Владимирович", true, 178, 83, "Русский"),
                new Criminal("Алексеев", "Владимир", "Андреевич", false, 180, 85, "Русский"),
                new Criminal("Морозов", "Михаил", "Васильевич", false, 176, 82, "Русский"),
                new Criminal("Кузнецов", "Игорь", "Петрович", true, 190, 95, "Русский")
             };

            foreach (Criminal criminal in criminals)
            {
                Console.WriteLine($"Фамилия: {criminal.Surname}, Имя: {criminal.Name}, Отчество: {criminal.Patronymic}, Взят ли под стражу: {(criminal.TakenIntoCustody ? "Да" : "Нет")}, Рост: {criminal.Height}, Вес: {criminal.Weight}, Национальность: {criminal.Nationality}");
            }

            PoliceDepartment policeDepartment = new PoliceDepartment(criminals);

            // Параметры детектива
            uint minHeight = 170;
            uint maxHeight = 190;
            uint minWeight = 80;
            uint maxWeight = 100;
            string nationality = "Русский";

            var suitableCriminals = policeDepartment.GetSuitableCriminals(minHeight, maxHeight, minWeight, maxWeight, nationality);

            Console.WriteLine("Подходящие преступники:");
            foreach (var criminal in suitableCriminals)
            {
                Console.WriteLine($"Фамилия: {criminal.Surname}, Имя: {criminal.Name}, Отчество: {criminal.Patronymic}, Рост: {criminal.Height}, Вес: {criminal.Weight}, Национальность: {criminal.Nationality}");
            }
        }
    }

    class Criminal
    {
        public Criminal(string surname, string name, string patronymic, bool takenIntoCustody, uint height, uint weight, string nationality)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            TakenIntoCustody = takenIntoCustody;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }

        public string Surname { get; }
        public string Name { get; }
        public string Patronymic { get; }
        public bool TakenIntoCustody { get; }
        public uint Height { get; }
        public uint Weight { get; }
        public string Nationality { get; }
    }

    class PoliceDepartment
    {
        public List<Criminal> Criminals { get; }

        public PoliceDepartment(List<Criminal> criminals)
        {
            Criminals = criminals;
        }

        public IEnumerable<Criminal> GetSuitableCriminals(uint minHeight, uint maxHeight, uint minWeight, uint maxWeight, string nationality)
        {
            var suitableCriminals = Criminals.Where(criminal => criminal.Height >= minHeight && criminal.Height <= maxHeight
                                                      && criminal.Weight >= minWeight && criminal.Weight <= maxWeight
                                                      && criminal.Nationality == nationality
                                                      && !criminal.TakenIntoCustody);

            return suitableCriminals;
        }
    }
}
