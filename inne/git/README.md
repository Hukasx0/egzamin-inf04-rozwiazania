# Najważniejsze komendy Git

Git jest systemem kontroli wersji, który umożliwia śledzenie zmian w plikach i współpracę nad projektem.

## 1. **git init**
Inicjalizuje nowe repozytorium Git w bieżącym katalogu.
```sh
git init
```

Utworzy nowe repozytorium Git, jeśli jeszcze nie istnieje.

## 2. **git clone <url>**
Klonuje istniejące repozytorium zdalne na lokalny komputer.
```sh
git clone https://github.com/uzytkownik/repozytorium.git
```

Sklonuje repozytorium z podanego URL do nowego katalogu.

## 3. **git status**
Wyświetla status repozytorium.
```sh
git status
```

Pokazuje zmiany w repozytorium, takie jak zmodyfikowane pliki, pliki gotowe do dodania do commit, pliki nierozpoznane itp.

## 4. **git add <plik>**
Dodaje zmodyfikowane pliki do tzw. "staging area" (obszaru przechowywania przed commitowaniem).
```sh
git add plik.txt
```

Dodaje plik `plik.txt` do obszaru staging. Można również użyć **git add .**, aby dodać wszystkie zmienione pliki.

## 5. **git commit -m "komentarz"**
Tworzy commit, czyli zapisuje zmiany z obszaru staging do repozytorium.
```sh
git commit -m "Pierwszy commit"
```

Tworzy commit z dodanymi wcześniej plikami i zapisuje je w historii projektu z podanym komentarzem.

## 6. **git log**
Wyświetla historię commitów.
```sh
git log
```

Pokazuje listę commitów w repozytorium, począwszy od najnowszego. Może zawierać informacje takie jak identyfikator commit, autor, data oraz wiadomość commit.

## 7. **git diff**
Porównuje zmiany w plikach.
```sh
git diff
```

Pokazuje zmiany, które zostały wprowadzone w plikach, ale jeszcze nie zostały dodane do commit.

## 8. **git push <remote> <branch>**
Wysyła lokalne commity do zdalnego repozytorium.
```sh
git push origin master
```

Wysyła lokalną gałąź `master` do zdalnego repozytorium o nazwie `origin`.

## 9. **git pull <remote> <branch>**
Pobiera zmiany ze zdalnego repozytorium i łączy je z lokalnym.
```sh
git pull origin master
```

Pobiera zmiany z gałęzi `master` z repozytorium `origin` i integruje je z lokalną gałęzią.

## 10. **git branch**
Wyświetla listę lokalnych gałęzi w repozytorium.
```sh
git branch
```

Pokazuje wszystkie dostępne gałęzie w lokalnym repozytorium. Gałąź, na której aktualnie pracujemy, jest zaznaczona gwiazdką.

## 11. **git branch <nazwa>**
Tworzy nową gałąź.
```sh
git branch nowa-galaz
```

Tworzy nową gałąź o nazwie `nowa-galaz`.

## 12. **git checkout <nazwa>**
Przełącza się na inną gałąź.
```sh
git checkout nowa-galaz
```

Przełącza na gałąź o nazwie `nowa-galaz`. Można również użyć **git checkout -b <nazwa>**, aby utworzyć i od razu przełączyć się na nową gałąź.

## 13. **git merge <nazwa-gałęzi>**
Łączy zmiany z innej gałęzi z aktualną gałęzią.
```sh
git merge nowa-galaz
```

Łączy zmiany z gałęzi `nowa-galaz` do bieżącej gałęzi.

## 14. **git remote -v**
Wyświetla informacje o zdalnych repozytoriach.
```sh
git remote -v
```

Pokazuje listę zdalnych repozytoriów, z którymi jest połączone lokalne repozytorium.

## 15. **git fetch**
Pobiera zmiany z zdalnego repozytorium, ale ich nie łączy z lokalną gałęzią.
```sh
git fetch
```

Pobiera zmiany ze zdalnego repozytorium, ale nie modyfikuje lokalnego repozytorium (można je później ręcznie połączyć).

## 16. **git reset <plik>**
Cofnie zmiany w pliku lub plikach, które zostały dodane do obszaru staging, ale nie zostały jeszcze skomitowane.
```sh
git reset plik.txt
```

Cofnie dodanie pliku `plik.txt` do staging area, ale nie usunie zmian w pliku.

## 17. **git rm <plik>**
Usuwa plik z repozytorium.
```sh
git rm plik.txt
```

Usuwa plik `plik.txt` z repozytorium i przygotowuje go do commitowania.

## 18. **git stash**
Zapisuje bieżące zmiany i przywraca czysty stan repozytorium.
```sh
git stash
```

Zapisuje zmiany w repozytorium, ale je usuwa z bieżącego katalogu roboczego. Pozwala to przełączyć się na inną gałąź bez utraty niezapisanych zmian.

## 19. **git stash pop**
Przywraca zapisane zmiany z poprzedniego **git stash**.
```sh
git stash pop
```

Przywraca zmiany zapisane przez ostatni **git stash** i usuwa je z listy zapisanych zmian.

## 20. **git tag <nazwa>**
Tworzy nowy tag w repozytorium.
```sh
git tag v1.0
```

Tworzy tag o nazwie `v1.0`, który może być użyty do oznaczenia ważnej wersji projektu.

---

### Wskazówki

- **git commit -a** automatycznie dodaje zmiany w śledzonych plikach do commitu, bez potrzeby używania **git add**.
- Warto używać rozgałęzień (branches) do pracy nad nowymi funkcjami, aby nie zakłócać głównej gałęzi projektu (np. **master** lub **main**).
- Regularne commitowanie zmian pomaga śledzić postęp i ułatwia późniejsze rozwiązywanie problemów.
