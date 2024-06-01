﻿using Stall_Rental_Management_System.Models;
using Stall_Rental_Management_System.Views.View_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stall_Rental_Management_System
{
    internal class ContractPresenter
    {
        // Fields
        private IContractView view;
        private IContractRepository contractRepository;
        private BindingSource contractBindingSource;
        private IEnumerable<ContractModel> contractList;

        public ContractPresenter(IContractView view, IContractRepository contractRepository)
        {
            this.contractBindingSource = new BindingSource();   
            this.view = view;
            this.contractRepository = contractRepository;
            //
            this.view.SetContractBindingSource(contractBindingSource);
            //
            this.view.SearchContract += SearchContract;
            this.view.AddNewContract += AddNewContract;
            this.view.UpdateContract += UpadateContract;
            // load all contract data;
            LoadAllContractData();

        }
        // methods

        private void LoadAllContractData()
        {
            
            contractList = contractRepository.GetAll();
            contractBindingSource.DataSource = contractList;
           
        }

        private void UpadateContract(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewContract(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SearchContract(object sender, EventArgs e)
        {
            contractList = contractRepository.GetByID(this.view.ContractId);
            contractBindingSource.DataSource = contractList;
        }
        // conotructor

    }

}