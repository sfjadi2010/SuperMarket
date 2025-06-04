namespace SuperMarketManager.UseCases.CategoryUseCases.Interfaces;

public interface IDeleteCategoryUseCase
{
    Task ExecuteAsync(int categoryId);
}