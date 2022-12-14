using AngleSharp.Dom;
using BlazorAppPet.Pages;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;


namespace BlazorPetProjectUnitTests
{
    public class Tests
    {
        private Bunit.TestContext context;
        private Mock<Counter> counterMock;

        [SetUp]
        public void Setup()
        {
            context = new Bunit.TestContext();
            counterMock = new Mock<Counter>();
            context.Services.AddScoped(x => counterMock.Object);
        }

        [Test]
        public void StartCountFieldZeroValue()
        {
            var component = context.RenderComponent<Counter>();

            Assert.IsNotNull(component);

            CountCheck(component, 0);

        }

        [Test]
        public void ButtonPlusOneCount()
        {
            var component = context.RenderComponent<Counter>();

            Assert.IsNotNull(component);

            CountCheck(component, 0);
            var buttonPlusOne = GetPlusButton(component, 1);

            Assert.IsNotNull(buttonPlusOne);

            buttonPlusOne.Click();
            CountCheck(component, 1);
        }

        [Test]
        public void ButtonPlusTwoCount()
        {
            var component = context.RenderComponent<Counter>();

            Assert.IsNotNull(component);

            CountCheck(component, 0);
            var buttonPlusOne = GetPlusButton(component, 2);

            Assert.IsNotNull(buttonPlusOne);

            buttonPlusOne.Click();
            CountCheck(component, 2);
        }

        [Test]
        public void ButtonPlusThreeCount()
        {
            var component = context.RenderComponent<Counter>();

            Assert.IsNotNull(component);

            CountCheck(component, 0);
            var buttonPlusOne = GetPlusButton(component, 3);

            Assert.IsNotNull(buttonPlusOne);

            buttonPlusOne.Click();
            CountCheck(component, 3);
        }


        private void CountCheck(IRenderedComponent<Counter> component, int count)
        {
            var counterValue = component.Find("p");
            Assert.That($"\r\n<p role=\"status\" qa-id=\"CounterValue\">Current count: {count}</p>", Is.EqualTo(counterValue.ToMarkup().ToString()));
        }

        private IElement? GetPlusButton(IRenderedComponent<Counter> component, int value)
        {
            var buttons = component.FindAll("button");

            return buttons.FirstOrDefault(b => b.TextContent.Equals($"+{value}"));
        }
    }
}


