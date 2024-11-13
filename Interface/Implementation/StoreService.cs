using DesafioNexas.Entities;
using DesafioNexas.Interface.Interfaces;
using DesafioNexas.Repositories;

namespace DesafioNexas.Interface.Implementation;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;

    public StoreService(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
    
    public async Task CadastrarLojaAsync(Store? store)
    {
        if (store == null)
        {
            throw new ArgumentNullException(nameof(store), "A loja não pode ser nulo.");
        }

        if (string.IsNullOrEmpty(store.Name))
        {
            throw new ArgumentException("O nome da loja não pode ser nulo nem vázio");
        }

        if (store.Name.Length > 250)
        {
            throw new ArgumentException("O nome da loja não pode ter mais de 250 caracteres");
        }

        if (store.Address?.Length > 250)
        {
            throw new ArgumentException("O endereço não pode ter mais de 250 caracteres");
        }

        if (string.IsNullOrEmpty(store.Address))
        {
            throw new ArgumentNullException("O endereço não pode ser nulo nem vázio");
        }
        
        await _storeRepository.CadastrarLojaAsync(store);
        
    }

    public async Task<Store?>? ObterLojaPorIdAsync(int id)
    {
        if (id < 0)
        {
            throw new ArgumentException("O ID da loja não pode ser negativo");
        }
        
        var store = await _storeRepository.ObterLojaPorIdAsync(id);
        
        if (store == null)
        {
            throw new Exception("A loja não existe ou não foi encontrada");
        }
        
        return store;
    }

    public async Task AlterarLojaAsync(int id, Store? storeAtualizado)
    {
        if (storeAtualizado == null)
        {
            throw new ArgumentException(nameof(storeAtualizado), "A loja não pode ser nula");
        }
        
        var lojaExistente= await _storeRepository.ObterLojaPorIdAsync(id);

        if (lojaExistente == null)
        {
            throw new Exception("A loja não existe ou não foi encontrada");
        }

        if (string.IsNullOrWhiteSpace(lojaExistente.Name))
        {
            throw new ArgumentException("O nome não pode ser vázio ou nulo");
        }

        if (storeAtualizado.Name?.Length > 250)
        {
            throw new Exception("O nome não pode ter mais de 250 caracteres");
        }

        if (string.IsNullOrWhiteSpace(lojaExistente.Address))
        {
            throw new ArgumentException("O endereço não pode ser vázio ou nulo");
        }

        if (storeAtualizado.Address?.Length > 250)
        {
            throw new Exception("O endereço não pode ter mais de 250 caracteres");
        }

        lojaExistente.AlterarNome(storeAtualizado.Name);
        lojaExistente.AlterarEndereço(storeAtualizado.Address);
        
        await _storeRepository.AlterarLojaAsync(id, storeAtualizado);
    }

    public async Task RemoverLojaAsync(int id)
    {
        if (id < 0)
        {
            throw new ArgumentException("O valor do ID não pode ser negativo");
        } 
        
        var loja = await _storeRepository.ObterLojaPorIdAsync(id);
        if (loja == null)
        {
            throw new Exception("A loja não existe ou não foi encontrado");
        }
        
        await _storeRepository.RemoverLojaAsync(id);
    }
}