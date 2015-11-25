using System;
using FakeItEasy;
using NUnit.Framework;
using UamTTA.Model;
using UamTTA.Services;
using UamTTA.Storage;

namespace UamTTA.Tests.Services
{
    [TestFixture]
    public class BudgetServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _budgetFactory = A.Fake<IBudgetFactory>();
            _repository = A.Fake<IRepository<Budget>>();

            _sut = new BudgetService(_budgetFactory, _repository);
        }

        private BudgetService _sut;
        private IBudgetFactory _budgetFactory;
        private IRepository<Budget> _repository;

        [Test]
        public void Create_Budget_Should_Create_Budget_Using_Factory()
        {
            var someTemplate = new BudgetTemplate();
            var someDate = DateTime.Today;

            _sut.CreateBudgetFromTemplate(someTemplate, someDate);

            A.CallTo(() => _budgetFactory.CreateBudget(someTemplate, someDate))
             .MustHaveHappened();
        }

        [Test]
        public void Should_Persist_Created_Budget_In_Repository()
        {
            var someBudget = new Budget();
            A.CallTo(() => _budgetFactory.CreateBudget(A<BudgetTemplate>._, A<DateTime>._))
                .Returns(someBudget);

            _sut.CreateBudgetFromTemplate(new BudgetTemplate(), DateTime.Today);

            A.CallTo(() => _repository.Persist(someBudget)).MustHaveHappened();
        }
    }
}