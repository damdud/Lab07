using System.Linq;
using NUnit.Framework;
using UamTTA.Model;
using UamTTA.Storage;

namespace UamTTA.Tests.Storage
{
    [TestFixture]
    [Ignore("To są testy integracyjne")]
    public class RepositoryTests
    {
        [SetUp]
        public void SetUp()
        {
            _sut = new Repository<Account>(() => new UamTTAContext());
            foreach (var account in _sut.GetAll())
            {
                _sut.Remove(account);
            }
        }

        private Repository<Account> _sut;

        [Test]
        public void FindById_Should_Return_Null_When_Object_Og_Given_Id_Was_Not_Found()
        {
            var actual = _sut.FindById(4475438);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void GetAll_Returns_All_Items()
        {
            var model1 = new Account { Id = null, Balance = 10, Name = "Bla" };
            var model2 = new Account { Id = null, Balance = 12, Name = "BlaBla" };

            _sut.Persist(model1);
            _sut.Persist(model2);
            var result = _sut.GetAll();

            Assert.That(result.Count(), Is.EqualTo(2));
            CollectionAssert.AllItemsAreUnique(result);
        }

        [Test]
        public void GetAll_Returns_Empty_Collection_When_Repository_Is_Empty()
        {
            var result = _sut.GetAll();

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void Persist_Should_Return_Copy_Of_Transient_Object_With_Id_Assigned()
        {
            var someTransientModel = new Account { Id = null, Balance = 10, Name = "Bla" };

            var result = _sut.Persist(someTransientModel);

            Assert.That(result, Is.Not.Null);

            Assert.That(result, Is.Not.SameAs(someTransientModel));
            Assert.That(result.Balance, Is.EqualTo(someTransientModel.Balance));
            Assert.That(result.Name, Is.EqualTo(someTransientModel.Name));
            Assert.That(result.Id.HasValue);
        }

        [Test]
        public void Persisted_Data_Should_Be_Accesible_By_Id_Via_FindById()
        {
            var someTransientModel = new Account { Id = null, Balance = 10, Name = "Bla" };

            var persisted = _sut.Persist(someTransientModel);
            var actual = _sut.FindById(persisted.Id.Value);

            Assert.That(actual.Id, Is.EqualTo(persisted.Id));
            Assert.That(actual.Balance, Is.EqualTo(persisted.Balance));
            Assert.That(actual.Name, Is.EqualTo(persisted.Name));
        }

        [Test]
        public void Persisted_Object_With_Already_Existing_Id_Should_Evict_Previus_Data()
        {
            var someTransientModel = new Account { Id = null, Balance = 10, Name = "Bla" };

            var persisted = _sut.Persist(someTransientModel);
            var anotherWithSameId = new Account { Id = persisted.Id, Balance = 1121210, Name = "xd^grrr" };
            _sut.Persist(anotherWithSameId);
            var actual = _sut.FindById(persisted.Id.Value);

            Assert.That(actual.Id, Is.EqualTo(persisted.Id));
            Assert.That(actual.Balance, Is.EqualTo(anotherWithSameId.Balance));
            Assert.That(actual.Name, Is.EqualTo(anotherWithSameId.Name));
        }

        [Test]
        public void Remove_Should_Remove_Item_Of_Same_Id_From_Storage()
        {
            var someTransientModel = new Account { Id = null, Balance = 10, Name = "Bla" };

            var persisted = _sut.Persist(someTransientModel);
            var anotherWithSameId = new Account { Id = persisted.Id };
            _sut.Remove(anotherWithSameId);

            var actual = _sut.FindById(persisted.Id.Value);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void Subsequent_Persist_Calls_Objects_Should_Assign_Different_Id()
        {
            var someTransientModel = new Account { Id = null, Balance = 10, Name = "Bla" };
            var anotherTransientModel = (Account)someTransientModel.Clone();

            var result1 = _sut.Persist(someTransientModel);
            var result2 = _sut.Persist(anotherTransientModel);

            Assert.That(result1, Is.Not.Null);
            Assert.That(result2, Is.Not.Null);

            Assert.That(result1, Is.Not.SameAs(someTransientModel));
            Assert.That(result2, Is.Not.SameAs(someTransientModel));
            Assert.That(result1, Is.Not.SameAs(result2));
            Assert.That(result1.Id, Is.Not.Null);
            Assert.That(result2.Id, Is.Not.Null);
            Assert.That(result1.Id, Is.Not.EqualTo(result2.Id));
        }
    }
}