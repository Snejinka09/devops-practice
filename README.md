# miniBank

Pet-проект: учебный банковский API на ASP.NET Core вместе с инфраструктурой мониторинга (Prometheus/Grafana) и полным циклом CI/CD на GitLab. Используется как площадка для практики C#/.NET и DevOps-навыков — не production-продукт.

## Архитектура

Репозиторий состоит из двух частей:

- **`app/`** — само приложение (.NET 8, ASP.NET Core Web API), слоёная архитектура:
  - `MiniBank.Core` — сущности (`Client`, `Account`, `Transaction`, `User`), интерфейсы репозиториев, сервисы с бизнес-логикой
  - `MiniBank.Api` — контроллеры, конфигурация DI, JWT-аутентификация, Swagger
  - `MiniBank.Tests` — юнит-тесты

Слой `Core` не зависит от `Api` — вся бизнес-логика изолирована от деталей HTTP и хранения данных, что позволяет тестировать сервисы независимо и безболезненно менять способ хранения данных (сейчас — in-memory, в планах — реальная БД).

## Стек технологий

- **.NET 8**, ASP.NET Core Web API
- **JWT** — аутентификация и авторизация (хеширование паролей через `PasswordHasher`)
- **Docker / Docker Compose** — упаковка и запуск сервисов
- **GitLab CI/CD** — self-hosted runner (Docker executor, DooD) на том же VPS
- **Prometheus + Grafana + Pushgateway** — мониторинг

## Возможности API

- Регистрация и логин (`/api/auth/register`, `/api/auth/login`) с выдачей JWT-токена
- CRUD для клиентов, счетов и транзакций (`/api/clients`, `/api/accounts`, `/api/transaction`)
- Все эндпоинты, кроме `auth`, защищены `[Authorize]` — требуют валидный Bearer-токен
- Документация и ручное тестирование через Swagger UI (доступен в Development-окружении)


## CI/CD

При пуше в `main` пайплайн автоматически:
1. Проверяет конфигурацию (`docker compose config`)
2. Обновляет и перезапускает стек на VPS (`docker compose pull && up -d`)

## Планы на будущее

- Подключение реальной базы данных вместо in-memory-хранилища + EF Core миграции
- Юнит-тесты для сервисного слоя
- Глобальная обработка исключений, валидация входных данных
- Реальные метрики приложения в Prometheus (через `prometheus-net`)
- Health-check эндпоинт, алерты
