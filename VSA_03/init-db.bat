@echo off
echo Criando banco de dados SQLite...
sqlite3.exe vsa03.db < create-db.sql
if %errorlevel% equ 0 (
    echo Banco criado com sucesso: vsa03.db
) else (
    echo Erro ao criar o banco. Verifique se o sqlite3.exe esta instalado e disponivel no PATH.
)
pause
