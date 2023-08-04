﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Serede.Core.Models.ViewModel;
public class ResultViewModel : Result
{
    public ResultViewModel(ModelStateDictionary data)
    {
        foreach (var erro in data)
        {
            foreach (var er in erro.Value.Errors)
            {
                AddNotification(erro.Key, er.ErrorMessage);
            }
        }
    }

    public ResultViewModel(IdentityResult data)
    {
        foreach (var erro in data.Errors)
        {
            AddNotification(erro.Code, erro.Description);
        }
    }

    public ResultViewModel(object data, ModelStateDictionary state)
    {
        Data = data;

        foreach (var erro in state)
        {
            foreach (var er in erro.Value.Errors)
            {
                AddNotification(erro.Key, er.ErrorMessage);
            }
        }
    }

    public ResultViewModel(object data, IdentityResult state)
    {
        Data = data;

        foreach (var erro in state.Errors)
        {
            AddNotification(erro.Code, erro.Description);
        }
    }

    public ResultViewModel() { }
    public ResultViewModel(object data){ }
    public ResultViewModel(int count){ }
    public ResultViewModel(object data, int count){ }
}