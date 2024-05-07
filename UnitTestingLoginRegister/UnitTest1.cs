using LoginRegister;

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
    }
}