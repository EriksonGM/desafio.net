using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioNET.Services.Enum
{
    public enum TransactionTypeEnum
    {
        [Display(Name = "Débito")]
        Debito = 1,
        Boleto,
        Financiamento,
        [Display(Name = "Crédito")]
        Credito,
        [Display(Name = "Recebimento Empréstimo")]
        RecebimentoEmprestimo,
        Vendas,
        RecebimentoTED,
        RecebimentoDOC,
        Aluguel
    }
}