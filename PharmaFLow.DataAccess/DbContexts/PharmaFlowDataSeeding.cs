using PharmaFlow.Utils;
using System.Collections.Generic;

namespace PharmaFLow.DataAccess.DbContexts;

internal static class PharmaFlowDataSeeding
{
    public static IList<UserPersistence> GetUsers()
    {
        SecurePasswordHasher hasher = new();

        return new List<UserPersistence>
        {
            new UserPersistence
            {
                FirstName = "Alexandr",
                LastName = "Cherednyk",
                Email = "admin@mail.com",
                Role = UserRolePersistence.Admin,
                PasswordHash = hasher.HashToString("password!"),
            },
            new UserPersistence
            {
                FirstName = "Ryan",
                LastName = "Gosling",
                Email = "manager@mail.com",
                Role = UserRolePersistence.Manager,
                PasswordHash = hasher.HashToString("password!"),
            },
            new UserPersistence
            {
                FirstName = "matt",
                LastName = "Johnson",
                Email = "pharmacist@mail.com",
                Role = UserRolePersistence.Pharmacist,
                PasswordHash = hasher.HashToString("password!"),
            },
        };
    }

    public static IList<ProductPersistence> GetProducts()
    {
        return new List<ProductPersistence>
        {
            new ProductPersistence
            {
                Name = "Цитрамон",
                Description = "Знеболюючий лікарський засіб призначають дорослим по 1 таблетці 2-3 рази на добу після прийому їжі.",
                Price = 20,
                Count = 450,
                PathToFile = null,
                Type = new ProductTypePersistence
                {
                    Name = "Ліки",
                },
                Manufacturer = new ProductManufacturerPersistence
                {
                    Name = "Україна",
                },
                Characteristics = new List<ProductCharacteristicPersistence>()
                {
                    new ProductCharacteristicPersistence()
                    {
                        Name = "Діючи речовини",
                        Value = "парацетамол, кофеїн, ацетилсаліцилова кислота",
                    },
                    new ProductCharacteristicPersistence()
                    {
                        Name = "Форма випуску",
                        Value = "таблетки",
                    },
                },
            },
            new ProductPersistence
            {
                Name = "Магне-В6",
                Description = "Таблетки слід ковтати цілими, запиваючи 1 склянкою води.",
                Price = 275,
                Count = 200,
                PathToFile = null,
                Type = new ProductTypePersistence
                {
                    Name = "Вітаміни і мінерали",
                },
                Manufacturer = new ProductManufacturerPersistence
                {
                    Name = "Германія",
                },
                Characteristics = new List<ProductCharacteristicPersistence>()
                {
                    new ProductCharacteristicPersistence()
                    {
                        Name = "Діючи речовини",
                        Value = "магній, піроксид",
                    },
                    new ProductCharacteristicPersistence()
                    {
                        Name = "Кількість в упаковці",
                        Value = "60 шт.",
                    },
                },
            },
            new ProductPersistence
            {
                Name = "Риб'ячий жир",
                Description = "Дорослим і дітям з 12 років по 1 капсулі на добу під час прийому їжі.",
                Price = 55,
                Count = 990,
                PathToFile = null,
                Type = new ProductTypePersistence
                {
                    Name = "Добавки",
                },
                Manufacturer = new ProductManufacturerPersistence
                {
                    Name = "Італія",
                },
                Characteristics = new List<ProductCharacteristicPersistence>()
                {
                    new ProductCharacteristicPersistence()
                    {
                        Name = "Кількість в упаковці",
                        Value = "10 шт.",
                    },
                },
            },
        };
    }

    public static IList<MedicalFacilityPersistence> GetMedicalFacilities()
    {
        List<ContactPersistence> contacts = new List<ContactPersistence>
        {
            new ContactPersistence
            {
                FirstName = "matt",
                LastName = "Phin",
                Email = "test@mail.com",
                Phone = "380976022331",
            },
            new ContactPersistence
            {
                FirstName = "Ryan",
                LastName = "Gosling",
                Email = "test@mail.com",
                Phone = "380976022331",
            },
            new ContactPersistence
            {
                FirstName = "matt",
                LastName = "Johnson",
                Email = "test@mail.com",
                Phone = "380976022331",
            },
        };

        MedicalFacilityTypePersistence type = new()
        {
            Name = "Аптека",
        };

        return new List<MedicalFacilityPersistence>
        {
            new MedicalFacilityPersistence
            {
                Name = "Аптека низьких цін",
                Type = type,
                Address = "вулиця Бульварно-Кудрявська, 7, Київ, 04053",
                Staff = new List<MedicalFacilityContactPersistence>
                {
                    new MedicalFacilityContactPersistence
                    {
                        Contact = contacts[0],
                        Position = new MedicalFacilityContactPositionPersistence
                        {
                            Name = "Менеджер",
                        },
                    },
                    new MedicalFacilityContactPersistence
                    {
                        Contact = contacts[1],
                        Position = new MedicalFacilityContactPositionPersistence
                        {
                            Name = "Фармацевт",
                        },
                    },
                },
            },
            new MedicalFacilityPersistence
            {
                Name = "Аптека Доброго Дня",
                Type = type,
                Address = "вулиця Богдана Хмельницького, 37, Київ, 02000",
                Staff = new List<MedicalFacilityContactPersistence>
                {
                    new MedicalFacilityContactPersistence
                    {
                        Contact = contacts[1],
                        Position = new MedicalFacilityContactPositionPersistence
                        {
                            Name = "Старший-фармацевт",
                        },
                    },
                    new MedicalFacilityContactPersistence
                    {
                        Contact = contacts[2],
                        Position = new MedicalFacilityContactPositionPersistence
                        {
                            Name = "Адміністратор",
                        },
                    },
                },
            }
        };
    }
}
