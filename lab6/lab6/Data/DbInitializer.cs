using Lab6.Data;

public static class DbInitializer
{
    public static void Initialize(CarServiceCenterContext context)
    {
        // Перевірка, чи є вже дані
        if (context.Manufacturers.Any()) return;

        // Додавання виробників
        var manufacturers = new[]
        {
            new Manufacturer { ManufacturerName = "Toyota", OtherManufacturerDetails = "Japanese Manufacturer" },
            new Manufacturer { ManufacturerName = "Ford", OtherManufacturerDetails = "American Manufacturer" },
            new Manufacturer { ManufacturerName = "BMW", OtherManufacturerDetails = "German Manufacturer" }
        };
        context.Manufacturers.AddRange(manufacturers);
        context.SaveChanges();

        // Додавання моделей
        var models = new[]
        {
            new Model { ModelName = "Camry", ManufacturerId = manufacturers[0].Id, OtherModelDetails = "Sedan" },
            new Model { ModelName = "Corolla", ManufacturerId = manufacturers[0].Id, OtherModelDetails = "Compact Sedan" },
            new Model { ModelName = "F-150", ManufacturerId = manufacturers[1].Id, OtherModelDetails = "Pickup Truck" },
            new Model { ModelName = "Mustang", ManufacturerId = manufacturers[1].Id, OtherModelDetails = "Sports Car" },
            new Model { ModelName = "X5", ManufacturerId = manufacturers[2].Id, OtherModelDetails = "SUV" }
        };
        context.Models.AddRange(models);
        context.SaveChanges();

        // Додавання клієнтів
        var customers = new[]
        {
            new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                Title = "Mr.",
                Gender = "Male",
                EmailAddress = "john.doe@example.com",
                PhoneNumber = "1234567890",
                AddressLine1 = "123 Main St",
                City = "Los Angeles",
                State = "CA",
                OtherCustomerDetails = "Preferred Customer"
            },
            new Customer
            {
                FirstName = "Jane",
                LastName = "Smith",
                Title = "Ms.",
                Gender = "Female",
                EmailAddress = "jane.smith@example.com",
                PhoneNumber = "9876543210",
                AddressLine1 = "456 Elm St",
                City = "New York",
                State = "NY",
                OtherCustomerDetails = "Loyal Customer"
            }
        };
        context.Customers.AddRange(customers);
        context.SaveChanges();

        // Додавання машин
        var cars = new[]
        {
            new Car { LicenceNumber = "ABC123", ModelId = models[0].Id, CustomerId = customers[0].Id, OtherCarDetails = "White Color" },
            new Car { LicenceNumber = "XYZ987", ModelId = models[2].Id, CustomerId = customers[1].Id, OtherCarDetails = "Black Color" }
        };
        context.Cars.AddRange(cars);
        context.SaveChanges();

        // Додавання механіків
        var mechanics = new[]
        {
            new Mechanic { MechanicName = "Mike Johnson", OtherMechanicDetails = "Experienced in SUVs" },
            new Mechanic { MechanicName = "Anna Brown", OtherMechanicDetails = "Specializes in sedans" }
        };
        context.Mechanics.AddRange(mechanics);
        context.SaveChanges();

        // Додавання бронювань
        var serviceBookings = new[]
        {
            new ServiceBooking
            {
                LicenceNumber = "SV1001",
                CustomerId = customers[0].Id,
                CarId = cars[0].Id,
                OtherSvcBookingDetails = "Oil Change"
            },
            new ServiceBooking
            {
                LicenceNumber = "SV1002",
                CustomerId = customers[1].Id,
                CarId = cars[1].Id,
                OtherSvcBookingDetails = "Brake Replacement"
            }
        };
        context.ServiceBookings.AddRange(serviceBookings);
        context.SaveChanges();

        // Додавання зв'язків механіків з бронюваннями
        var mechanicsOnServices = new[]
        {
            new MechanicsOnServices { MechanicId = mechanics[0].Id, SvcBookingId = serviceBookings[0].Id },
            new MechanicsOnServices { MechanicId = mechanics[1].Id, SvcBookingId = serviceBookings[1].Id }
        };
        context.MechanicsOnServices.AddRange(mechanicsOnServices);
        context.SaveChanges();
    }
}
