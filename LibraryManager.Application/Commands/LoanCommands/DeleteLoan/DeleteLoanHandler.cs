﻿using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.LoanCommands.DeleteLoan
{
    public class DeleteLoanHandler : IRequestHandler<DeleteLoanCommand, ResultViewModel>
    {
        private readonly ILoanRepository _repository;
        public DeleteLoanHandler(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _repository.GetById(request.Id);
            if (loan is null)
                return ResultViewModel.Error("Loan not found.");
            loan.SetAsDeleted();

            await _repository.Update(loan);

            return ResultViewModel.Success();
        }
    }
}
