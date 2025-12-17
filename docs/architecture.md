# System Architecture – Tele-Rehab Platform (MVP)

## 1. Overview

Tele-Rehab Platform — web-based tele-rehabilitation system that enables
patients and doctors to conduct online rehabilitation sessions via video calls.

Architecture is designed as a **modular monorepo** with clear separation
between frontend, backend, and infrastructure.

The system follows a **client–server architecture**.

---

## 2. High-Level Architecture

[ Browser (Patient / Doctor) ]
|
| HTTPS
v
[ Frontend (React) ]
|
| REST API (JWT)
v
[ Backend (.NET Web API) ]
|
| ORM (EF Core)
v
[ PostgreSQL Database ]


        |
        | External Service
        v
  [ Jitsi Meet Server ]

## 3. Frontend Architecture

**Technology:** React (SPA)

**Responsibilities:**
- User authentication (login/register)
- Appointment booking UI
- Video session UI (Jitsi integration)
- Session history display

**Key Concepts:**
- Communicates with backend via REST API
- Uses JWT for authentication
- Jitsi embedded via iframe or SDK

---

## 4. Backend Architecture

**Technology:** .NET Web API

**Architecture Pattern:** Clean Architecture (simplified for MVP)

### Layers:

API
│
├── Application
│ ├── Use cases
│ ├── DTOs
│ └── Interfaces
│
├── Domain
│ ├── Entities (Patient, Doctor, Session)
│ └── Business rules
│
├── Infrastructure
│ ├── Database (EF Core)
│ ├── Authentication
│ └── External services


**Responsibilities:**
- Authentication & authorization
- Business logic
- Session management
- Integration with Jitsi
- Payment flow handling


## 5. Database Design (MVP – Logical)

**Core entities:**
- Users (Patient / Doctor)
- Appointments
- Sessions
- Payments

Database:
- PostgreSQL
- Managed via Entity Framework Core


## 6. Video Communication (Jitsi)

- Jitsi Meet deployed separately (Docker)
- Backend generates meeting room identifiers
- Frontend joins sessions using Jitsi URL
- Video traffic does NOT pass through backend

## 7. Infrastructure Architecture

**Deployment:**
- VPS (Linux)
- Docker & docker-compose
- Nginx Proxy Manager as reverse proxy

**Components:**
- Frontend container
- Backend container
- PostgreSQL container
- Jitsi Meet containers

## 8. Security (MVP Level)

- HTTPS via Nginx Proxy Manager
- JWT-based authentication
- Role-based access (Patient / Doctor / Admin)
- No medical record storage in MVP

---

## 9. Non-Goals (Explicitly Excluded)

- Mobile applications
- AI/ML features
- Offline mode
- Full EMR integration

---

## 10. Architecture Principles

- Simplicity over completeness
- MVP-first approach
- Clear separation of concerns
- Easy to extend after MVP
