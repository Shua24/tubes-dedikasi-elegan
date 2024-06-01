using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginRegister;
using static LoginRegister.UserLogin;

namespace UnitTestingLoginRegister
{
    [TestClass]
    public class LoginRegisterAutomataTest
    {
        [TestMethod]
        public void AutomataTest()
        {
            // Arrange
            LoginState expected = LoginState.SUDAH_LOGIN;

            // Act
            StateLogin state = new StateLogin();
            LoginState result = state.NextState(state.current, Trigger.LOGIN);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TableDrivenTest()
        {
            // Arrange
            string expectedUsername = "Rakha";

            // Act
            string result = UserList.s_GetUsername(UserList.User.rakha);

            // Assert
            Assert.AreEqual(expectedUsername, result);
        }

        [TestMethod]
        public void CodeReuseLibraryTest()
        {
            // Arrange
            LoginState expected = LoginState.SUDAH_LOGIN;

            // Act
            StateLogin state = new StateLogin();
            LoginState result = state.NextState(state.current, Trigger.LOGIN);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
