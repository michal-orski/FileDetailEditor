using FileDetailEditor.ViewModels;

namespace FileDetailEditorTests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void MainViewModel_Constructor_ShouldInitializeProperties()
        {
            // Act
            var viewModel = new MainViewModel();

            // Assert
            // Add assertions here
            Assert.IsNotNull(viewModel);
            Assert.IsInstanceOfType(viewModel, typeof(MainViewModel));
        }
    }
}
