# Backend - rzeczy do ogarnięcia

## 1. Custom Exceptions

- ✅ Stwórz klasę bazową `DomainException` w `InvenTracker.Domain/Exceptions/`
- ✅ Stwórz `NotFoundException : DomainException`
- ✅ Stwórz `ConflictException : DomainException`
- ✅ Stwórz `ForbiddenException : DomainException`
- ✅ Zamień wszystkie `throw new Exception(...)` w handlerach na odpowiednie custom exceptions

## 2. Global Exception Middleware

- ✅ Stwórz `ExceptionHandlingMiddleware` w `InvenTracker.Server/Middleware/`
- ✅ Obsłuż `NotFoundException` → 404
- ✅ Obsłuż `ValidationException` → 400
- ✅ Obsłuż `ConflictException` → 409
- ✅ Obsłuż `ForbiddenException` → 403
- ✅ Obsłuż wszystko inne → 500
- ✅ Zarejestruj middleware w `Program.cs` (przed `UseAuthentication`)

## 3. Spójny format błędów

- ✅ Stwórz klasę `ErrorResponse` (np. `{ Message, Errors[], StatusCode }`) w `InvenTracker.Application/Common/`
- ✅ Użyj `ErrorResponse` w middleware zamiast zwracać surowy wyjątek

## 4. Validatory

- ✅ Stwórz `CreateCompanyCommandValidator`
- ✅ Stwórz `CreateItemCommandValidator`
- ✅ Stwórz `CreateWardrobeCommandValidator`
- ✅ Stwórz `CreateDepartmentCommandValidator`
- ✅ Stwórz `CreateWorkOrderCommandValidator`

## 5. Logging (Serilog)

- ✅ Dodaj pakiety `Serilog.AspNetCore` i `Serilog.Sinks.Console` do `InvenTracker.Server`
- ✅ Skonfiguruj Serilog w `Program.cs`
- ✅ Dodaj logowanie błędów w `ExceptionHandlingMiddleware`
- ✅ Dodaj `ILogger` do kilku handlerów (np. Login, CreateItem) i zaloguj kluczowe operacje