# UserAuthApp

Запросы SSMS:

CREATE DATABASE UserAuthDb;


USE UserAuthDb;

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(512) NOT NULL
);


Выход:
      1)
1. Вход
2. Регистрация
Выберите действие: 2

Введите имя пользователя: dsa
Введите пароль: 321

Добро пожаловать в главное меню!
1. Выйти
Выберите действие:
      2)
1. Вход
2. Регистрация
Выберите действие: 1

Имя пользователя: dsa
Пароль: 321

Добро пожаловать в главное меню!
1. Выйти
Выберите действие:
