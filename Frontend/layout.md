# Navigation

- [Besucher nicht eingeloggt]
  - Empty Bar
- [Besucher eingeloggt]
  - GraphView
  - Settings (Dropdown)
    - [nicht Admin]
      - new Password
    - [Admin]
      - new Password
      - Admin Panel
  - Logout

---

# Page GraphView /graph

- [Besucher nicht eingeloggt]
  - Redirect to Login Page
- [Besucher eingeloggt]
  - left: Toggle Views
  - right: View Content

---

# Page Login /auth/login

- [Besucher nicht eingeloggt]
  - Anmeldeformular
- [Besucher eingeloggt]
  - Redirect to GraphView

---

# Page Admin Panel /admin/setting

- [Besucher nicht eingeloggt]
  - Redirect to Login
- [Besucher nicht admin]
  - Redirect to GraphView
- [Besucher ist admin]
  - Benutzerverwaltung
  - IoT-Verwaltung

---

# Page New Password /edit/password

- [Besucher nicht eingeloggt]
  - Redirect to Login
- [Besucher eingeloggt]
  - NewPassword Formular
