using CabInvoiceGenerator;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()//this test case is used to check if fare matches with expected for normal ride
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }
        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSummary()//this test case is used to check if fare or multiple rides matches with expected values for normal ride
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 31.0);
            Assert.AreEqual(summary, expectedSummary);
        }
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFareforPremium()//this test case is used to check if fare matches with expected for premium ride
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 25;
            int time = 7;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 389;
            Assert.AreEqual(expected, fare);
        }
        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSummaryforPremium()//this test case is used to check if fare or multiple rides matches with expected values for premium ride
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(10.0, 7), new Ride(15, 8) };//164,241
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 405);
            Assert.AreEqual(summary, expectedSummary);
        }
        [Test]
        public void GivenUserIdShouldReturnListOfRidesFromRepo() //this test case is used to check the rides store in repository matches with expected values
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5), new Ride(3.0, 5) };//25,6,35
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRide("1", rides);
            var rideArray = rideRepository.getRides("1");
            InvoiceSummary summary = new InvoiceSummary(3, 66.0);
            InvoiceSummary expected = invoiceGenerator.CalculateFare(rideArray);
            Assert.AreEqual(expected, summary);
        }
    }
}