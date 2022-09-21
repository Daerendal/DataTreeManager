# DataTreeManager

Po uruchomieniu strony internetowej jesteśmy automatycznie łączeni z bazą danych MySql umieszczonej w chmurze - dlatego mamy natychmiastowy dostęp do zawartej w niej danych.
Strona internetowa składa się z dwóch głównych podstron które mają znaczenie dla użytkownika obsługującego nasze drzewa (oba dostępne z górnego menu) :
    1. Widoku drzew, w którym mamy dostęp do prostego widoku naszych drzew z wszystkimi gałęziami. Mamy tutaj również opcje sortowania naszych drzew wd. Nazw oraz numeru ID.
    2. Widoku edycji, gdzie mamy dostęp do możliwości usuwania, dodawania, edytowania i zmiany rodzica gałęzi. Dzieci danego rodzica odznaczone są odstępem od niego oraz odpowiednio ciemniejszym kolorem w linijkach po nich. Dzieci na tym samym poziomie są oznaczone takim samym kolorem.
      a.Usuwanie gałęzi. Usuwamy gałąź poprzez naciśnięcie "Usuń" obok gałęzi którą chcemy usunąć.
      b.Zmiana nazwy. Zmieniamy nazwę gałęzi poprzez wpisanie nowej nazwy i kliknięcie "Zmień nazwę" pod tym przyciskiem.
      c.Zmiana rodzica. Zmieniamy rodzica wpisując jego adres IP i potwierdzając zmianę kliknięciem w "Zmień rodzica"
      d.Dodanie gałęzi. Aby dodać gałąź wpisujemy nazwę nowej gałęzi i potwierdzamy to kliknięciem w zielony przycisk "Dodaj nową gałąź". Jeśli użyjemy opcji gałąź bezpośrednio po danej gałęzi, zostanie ona dodana jako jego dziecko. Aby dodać gałąź jako równoważną, należy dodać ją po opcji dodania dla dzieci. Dla uproszczenia wykorzystane są tutaj kolory, pomagające użytkownikowi znaleść odpowiednią opcję - jako iż opcja dodająca funkcje jest oznaczona takim samym tłem co jej gałąź.+
