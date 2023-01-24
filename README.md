# Projekt_bank
Program do działania potrzebuje serwera Apacha, który przechowuje bazę danych.
Polecam program XAMPP.
Baza Danych:

-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 04 Sty 2023, 12:45
-- Wersja serwera: 10.4.25-MariaDB
-- Wersja PHP: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `bank`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `karta`
--

CREATE TABLE `karta` (
  `nr_karty` bigint(11) NOT NULL,
  `data_waznosci` date NOT NULL,
  `CVV` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Zrzut danych tabeli `karta`
--

INSERT INTO `karta` (`nr_karty`, `data_waznosci`, `CVV`) VALUES
(0, '2020-01-01', 0),
(1231231233, '2022-11-24', 123),
(3857161000, '2022-12-01', 397),
(3857161002, '2022-12-01', 646),
(3857161017, '2022-12-05', 749),
(3857161018, '2022-12-06', 704),
(3857161023, '2022-12-12', 471);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `klient`
--

CREATE TABLE `klient` (
  `id_klienta` int(11) NOT NULL,
  `imie` text CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `nazwisko` text CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `adres` text COLLATE utf8mb4_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Zrzut danych tabeli `klient`
--

INSERT INTO `klient` (`id_klienta`, `imie`, `nazwisko`, `adres`) VALUES
(15, 'Piotr', 'Niemiec', 'Dolowa 222'),
(16, 'Tomek', 'Zburek', 'Krzywa 299'),
(17, 'Miroslaw', 'Zenent', 'Pułanki 3'),
(18, 'Alojzy', 'Torpeda', 'Ksieżycowa 112'),
(19, 'Sylwia', 'Polan', 'Polna 22'),
(20, 'Bogdan', 'Podsiadło', 'Sobieskiego 12');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `konfiguracja`
--

CREATE TABLE `konfiguracja` (
  `wolny_nr` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Zrzut danych tabeli `konfiguracja`
--

INSERT INTO `konfiguracja` (`wolny_nr`) VALUES
(1111000077791);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `konto`
--

CREATE TABLE `konto` (
  `id_konta` int(11) NOT NULL,
  `id_klienta` int(11) NOT NULL,
  `stan_konta` int(11) NOT NULL,
  `nr_konta` bigint(20) NOT NULL,
  `haslo` text COLLATE utf8mb4_polish_ci NOT NULL,
  `czy_karta` bigint(4) NOT NULL,
  `uprawnienia` tinyint(4) NOT NULL,
  `blokada` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Zrzut danych tabeli `konto`
--

INSERT INTO `konto` (`id_konta`, `id_klienta`, `stan_konta`, `nr_konta`, `haslo`, `czy_karta`, `uprawnienia`, `blokada`) VALUES
(1018, 15, 45, 1111000077785, 'qwer', 3857161018, 0, 0),
(1019, 16, 0, 1111000077786, 'qwe', 0, 0, 0),
(1020, 17, 38, 1111000077787, 'jezioro123', 0, 0, 0),
(1021, 18, 0, 1111000077788, '123', 0, 0, 0),
(1022, 19, 0, 1111000077789, 'asd', 0, 0, 0),
(1023, 20, 55, 1111000077790, 'most1', 3857161023, 0, 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `przelewy`
--

CREATE TABLE `przelewy` (
  `id_przelewu` int(11) NOT NULL,
  `data` date NOT NULL,
  `czas` time NOT NULL,
  `kwota` int(11) NOT NULL,
  `nadawca` bigint(20) NOT NULL,
  `odbiorca` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Zrzut danych tabeli `przelewy`
--

INSERT INTO `przelewy` (`id_przelewu`, `data`, `czas`, `kwota`, `nadawca`, `odbiorca`) VALUES
(1, '2022-10-25', '18:56:39', 10, 1050141640253641, 1050141640253640),
(2, '2022-11-20', '18:56:39', 5, 1050141640253641, 1050141640253640),
(3, '2022-11-20', '18:56:39', 5, 1050141640253641, 1050141640253640),
(18, '2022-11-20', '18:56:39', 10, 1050141640253641, 1111000077779),
(19, '2022-11-20', '18:56:39', 10, 1050141640253641, 1111000077779),
(20, '2022-11-20', '18:56:39', 50, 1050141640253641, 1111000077778),
(22, '2022-11-20', '18:56:39', 15, 1111000077779, 1111000077778),
(23, '2022-11-10', '21:19:42', 9, 1111000077778, 1111000077779),
(24, '2022-11-20', '18:56:39', 20, 1050141640253641, 1111000077781),
(25, '2022-11-20', '18:56:39', 2, 1050141640253641, 1111000077781),
(26, '2022-11-20', '18:56:39', 1, 1050141640253641, 1111000077781),
(27, '0000-00-00', '18:56:39', 10, 1050141640253641, 1111000077782),
(28, '0000-00-00', '18:56:39', 10, 1050141640253641, 1111000077782),
(29, '2022-11-30', '18:56:39', 1, 1050141640253641, 1111000077782),
(30, '2022-11-30', '18:56:39', 1, 1050141640253641, 1111000077782),
(31, '2022-11-30', '18:56:39', 2, 1050141640253641, 1111000077782),
(32, '2022-11-30', '18:56:39', 5, 1050141640253641, 1111000077780),
(33, '2022-11-30', '12:33:00', 11, 1050141640253641, 1111000077780),
(34, '2022-12-07', '09:51:00', 15, 1050141640253641, 1111000077784),
(35, '2022-12-07', '10:04:00', 0, 1050141640253641, 1111000077778),
(36, '2022-12-07', '10:10:00', 11, 1050141640253641, 1111000077787),
(38, '2022-12-07', '10:28:00', 1, 1111000077787, 1111000077780),
(39, '2022-12-07', '10:35:00', 5, 1111000077787, 1111000077784),
(40, '2022-12-12', '19:53:00', 45, 1111000077790, 1111000077785);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `karta`
--
ALTER TABLE `karta`
  ADD PRIMARY KEY (`nr_karty`);

--
-- Indeksy dla tabeli `klient`
--
ALTER TABLE `klient`
  ADD PRIMARY KEY (`id_klienta`);

--
-- Indeksy dla tabeli `konto`
--
ALTER TABLE `konto`
  ADD PRIMARY KEY (`id_konta`),
  ADD KEY `rel1` (`id_klienta`),
  ADD KEY `rel_kart` (`czy_karta`);

--
-- Indeksy dla tabeli `przelewy`
--
ALTER TABLE `przelewy`
  ADD PRIMARY KEY (`id_przelewu`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `karta`
--
ALTER TABLE `karta`
  MODIFY `nr_karty` bigint(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3857161024;

--
-- AUTO_INCREMENT dla tabeli `klient`
--
ALTER TABLE `klient`
  MODIFY `id_klienta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT dla tabeli `konto`
--
ALTER TABLE `konto`
  MODIFY `id_konta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1024;

--
-- AUTO_INCREMENT dla tabeli `przelewy`
--
ALTER TABLE `przelewy`
  MODIFY `id_przelewu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `konto`
--
ALTER TABLE `konto`
  ADD CONSTRAINT `rel1` FOREIGN KEY (`id_klienta`) REFERENCES `klient` (`id_klienta`),
  ADD CONSTRAINT `rel_kart` FOREIGN KEY (`czy_karta`) REFERENCES `karta` (`nr_karty`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
