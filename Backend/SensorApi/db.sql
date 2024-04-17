

CREATE TABLE IF NOT EXISTS graph
(
    device_id uuid,
    time timestamp,
    value_kelvin float,
    PRIMARY KEY (device_id, time)
    );

CREATE TABLE IF NOT EXISTS iot_device
(
    id uuid,
    name TEXT UNIQUE,
    last_request timestamp,
    allowed_request bool,
    PRIMARY KEY (id)
    );

CREATE TABLE IF NOT EXISTS user_cookie
(
    id TEXT,
    end_datetime timestamp,
    user_id uuid,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS user_info (
    id uuid NOT NULL,
    username TEXT NOT NULL,
    password_hash TEXT NOT NULL,
    is_admin bool NOT NULL
);