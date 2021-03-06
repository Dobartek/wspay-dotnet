namespace WSPay.Net
{
    using System.Threading.Tasks;

    public interface IWSPayService
    {
        Task<ProcessPaymentResponse> ProcessPaymentAsync(string shoppingCartId, double price, string token,
            string tokenNumber);

        ProcessPaymentResponse ProcessPayment(string shoppingCartId, double price, string token, string tokenNumber);
        
        Task<ChangeTransactionStatusResponse> CompleteTransactionAsync(Shop shop, string wsPayOrderId, string stan,
            string approvalCode, double price);

        ChangeTransactionStatusResponse CompleteTransaction(Shop shop, string wsPayOrderId, string stan,
            string approvalCode, double price);
        
        Task<ChangeTransactionStatusResponse> RefundTransactionAsync(Shop shop, string wsPayOrderId, string stan,
            string approvalCode, double price);

        ChangeTransactionStatusResponse RefundTransaction(Shop shop, string wsPayOrderId, string stan,
            string approvalCode, double price);
        
        Task<ChangeTransactionStatusResponse> VoidTransactionAsync(Shop shop, string wsPayOrderId, string stan,
            string approvalCode, double price);

        ChangeTransactionStatusResponse VoidTransaction(Shop shop, string wsPayOrderId, string stan,
            string approvalCode, double price);
        
        Task<StatusCheckResponse> CheckStatusAsync(Shop shop, string shoppingCartId);
        
        StatusCheckResponse CheckStatus(Shop shop, string shoppingCartId);
    }
}