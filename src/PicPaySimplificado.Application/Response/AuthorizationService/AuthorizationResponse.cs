namespace PicPaySimplificado.Application.Response.AuthorizationService;

public record AuthorizationResponse(string status, object data);
public record Data(bool authorization);