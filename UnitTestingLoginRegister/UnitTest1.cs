using LoginRegister;
using static LoginRegister.UserList;

namespace UnitTestingLoginRegister
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AutomataTest()
        {
            //Arange
            LoginState expected = LoginState.SUDAH_LOGIN;

            //Act
            StateLogin state = new StateLogin();
            LoginState result = state.NextState(state.Current, Trigger.LOGIN);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TableDrivenTest()
        {
            // Arrange
            string expectedUsername = "Rakha";

            // Act
            string result = UserList.GetUsername(UserList.User.rakha);

            // Assert
            Assert.AreEqual(result, expectedUsername);
            
        }

        [TestMethod]
        public void CodeReuseLibraryTest()
        {
            //Arange
            LoginState expected = LoginState.SUDAH_LOGIN;

            //Act
            StateLogin state = new StateLogin();
            LoginState result = state.NextState(state.Current, Trigger.LOGIN);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}