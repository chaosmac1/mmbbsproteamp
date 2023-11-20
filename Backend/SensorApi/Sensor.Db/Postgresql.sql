CREATE TABLE IF NOT EXISTS user_info
(
    id            uuid    NOT NULL PRIMARY KEY,
    username      TEXT    NOT NULL UNIQUE,
    password_hash TEXT    NOT NULL,
    is_admin      boolean NOT NULL
);

CREATE TABLE IF NOT EXISTS user_cookie
(
    id           TEXT      NOT NULL PRIMARY KEY,
    user_id      uuid      NOT NULL REFERENCES user_info (id) ON DELETE CASCADE,
    end_datetime timestamp NOT NULL
);

CREATE TABLE IF NOT EXISTS iot_device
(
    id              uuid      NOT NULL PRIMARY KEY,
    name            TEXT      NOT NULL UNIQUE,
    last_request    timestamp NOT NULL,
    allowed_request boolean   NOT NULL
);

CREATE TABLE IF NOT EXISTS graph
(
    id           BIGSERIAL NOT NULL PRIMARY KEY,
    device_id    UUID      NOT NULL REFERENCES iot_device (id) ON DELETE CASCADE,
    time         timestamp,
    value_kelvin FLOAT
);

create table IF NOT EXISTS log
(
    id             bigserial NOT NULL primary key,
    entered_date   timestamp NOT NULL default now(),
    log_date       text,
    log_level      text,
    log_logger     text,
    log_message    text,
    log_call_site  text,
    log_thread     text,
    log_exception  text,
    log_stacktrace text
);

alter table log
    owner to lambda