using HomeWork.Abstract;
using HomeWork.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Concrete
{
    class GameSellerManager
    {
        //Genel bir Sell operasyonu ile Sell islemilerini gormek istiyoruz ama hangi oyunu istersem onu gormek istiyorum
        IKampanyaCheckService _kampanyaCheckService;
        KampanyaType _kampanyaType;
        public GameSellerManager(IKampanyaCheckService kampanyaCheckService, KampanyaType kampanyaType)
        {
            _kampanyaCheckService = kampanyaCheckService;
            _kampanyaType = kampanyaType;
        }

        public void Sell(IGameSeller gameSeller, Person person)
        {
            if (_kampanyaCheckService.CheckIfKampanyaValid())
            {
                _kampanyaType.KampanyaDescribe();
                gameSeller.Sell(person);
            }else
            {
                _kampanyaType.NoKampanya();
                gameSeller.Sell(person);
            }
        }
    }
}

//Burda biz hangi oyun ne kadar satildigini gormek istersek burda secip de gorelim diye 