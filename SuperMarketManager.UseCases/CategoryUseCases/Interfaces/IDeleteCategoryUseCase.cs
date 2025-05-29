namespace SuperMarketManager.UseCases.CategoryUseCases.Interfaces;

public interface IDeleteCategoryUseCase
{
    Task Execute(int categoryId);
}