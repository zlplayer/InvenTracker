# InvenTracker

System do zarządzania inwentarzem w szafach magazynowych. Firmy i ich oddziały mają przypisane szafy, szafy dzielą się na szuflady i przegrody, a w przegrodach leżą przedmioty. Użytkownicy pobierają przedmioty na podstawie zleceń, dostawcy uzupełniają stany, a system pilnuje minimalnych ilości i wysyła alert e-mail, gdy stan spadnie poniżej progu.

## Funkcje

- **Firmy i oddziały** z adresami i przypisanymi szafami
- **Szafy, szuflady, przegrody**: konfiguracja układu szafy i podgląd zawartości każdej przegrody
- **Katalog przedmiotów** (opakowania, ilość w opakowaniu, status)
- **Stany magazynowe** w przegrodach z wartością minimalną
- **Zlecenia (work orders)**: lista przedmiotów do pobrania z szafy, wykonywana po kodzie; pobranie odbywa się metodą FIFO
- **Uzupełnianie stanów** przez dostawcę
- **Historia operacji** (pobrania, zwroty, uzupełnienia) z eksportem do PDF
- **Alert e-mail o niskim stanie**, wysyłany do osób odpowiedzialnych za szafę
- **Uwierzytelnianie JWT** z refresh tokenem i **4 role** z różnymi uprawnieniami

## Role i uprawnienia

| Rola | W skrócie |
|---|---|
| **Admin** | Pełny dostęp, jako jedyny zarządza firmami, oddziałami i użytkownikami |
| **Technik** | Obsługa techniczna: szafy, ich zawartość, katalog przedmiotów, zlecenia |
| **User** | Pracownik: wykonuje zlecenia (pobiera przedmioty z szafy) |
| **Dostawca** | Uzupełnia stany przedmiotów, które już są w szafach |


✅ pełny dostęp · 👁️ tylko podgląd · ❌ brak dostępu

| Obszar / akcja | Admin | Technik | User | Dostawca |
|---|:---:|:---:|:---:|:---:|
| **Dashboard** | ✅ | ✅ | ✅ | ✅ |
| **Szafy**: lista i szczegóły | ✅ | ✅ | ✅ | ✅ |
| Szafy: dodawanie, edycja, usuwanie | ✅ | ✅ | ❌ | ❌ |
| Szafy: konfiguracja szuflad i przegród | ✅ | ✅ | ❌ | ❌ |
| Przegroda: dodanie, podmiana, usunięcie przedmiotu | ✅ | ✅ | ❌ | ❌ |
| Przegroda: uzupełnienie stanu | ✅ | ✅ | ❌ | ✅ |
| Szafy: historia operacji i raport PDF | ✅ | ✅ | ❌ | ❌ |
| **Zlecenia**: lista, tworzenie, usuwanie | ✅ | ✅ | ❌ | ❌ |
| Zlecenia: wykonanie (pobranie przedmiotów) | ✅ | ✅ | ✅ | ❌ |
| Zwrot przedmiotu do szafy | ✅ | ✅ | ✅ | ❌ |
| Własna historia pobrań | ✅ | ✅ | ✅ | ❌ |
| **Firmy i oddziały** | ✅ | 👁️ | ❌ | ❌ |
| **Katalog przedmiotów** (inwentarz) | ✅ | ✅ | ❌ | ❌ |
| **Użytkownicy**: lista | ✅ | 👁️ | ❌ | ❌ |
| Użytkownicy: dodawanie, edycja, zmiana roli i hasła, usuwanie | ✅ | ❌ | ❌ | ❌ |
| Osoby odpowiedzialne za szafę | ✅ | ✅ | ❌ | ❌ |