-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 24 May 2019, 18:13:43
-- Sunucu sürümü: 10.1.39-MariaDB
-- PHP Sürümü: 7.3.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `otelbilgisistemi`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `calisan`
--

CREATE TABLE `calisan` (
  `id` int(11) NOT NULL,
  `tc` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `adsoyad` varchar(70) COLLATE utf8_turkish_ci NOT NULL,
  `telefon` varchar(14) COLLATE utf8_turkish_ci NOT NULL,
  `puan` int(11) NOT NULL,
  `adres` text COLLATE utf8_turkish_ci NOT NULL,
  `mail` varchar(70) COLLATE utf8_turkish_ci NOT NULL,
  `departman` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `otelid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `calisan`
--

INSERT INTO `calisan` (`id`, `tc`, `adsoyad`, `telefon`, `puan`, `adres`, `mail`, `departman`, `otelid`) VALUES
(2, '37584912674', 'Onur Yüksekkaya', '0532 417 6579', 95, 'Kanyoncu Mah Turkiye Bulvari', 'onurgama@gmail.com', 'Müdür', 7),
(5, '60264387915', 'Ömer Emre Elmali', '0554 657 8184', 80, 'Bayrampasa Mah   Kasimpasa Caddesi', 'omerelmali@gmail.com', 'Tekniker', 7),
(6, '45843879157', 'Onur Yüksekkaya', '0541 422 9114', 0, 'Bornova Mah   Alsancak Caddesi', 'iletisim@onuryuksekkaya.com', 'Müdür', 10),
(7, '67902637486', 'Oguzhan Kilinç', '0530 651 4121', 0, 'Etiler caddesi mesgut bulvari ', 'oguzhankk@hotmail.com', 'Barista', 10),
(8, '31452637455', 'Emre Kizil', '0530 113 4155', 0, 'Hakanlar caddesi  çiçek mahallesi', 'emrered@outlook.com', 'Resepsiyon', 10),
(10, '12345678912', 'Mehmet Uslu', '5301234567', 0, 'cumhuriyet mah', 'mehmetuslu@gmail.com', 'Insan Kaynaklari', 13),
(11, '12345678912', 'Mehmet uslu', '124243532', 0, 'cumhuriyet mah', 'mehmet@gmail.com', 'Insan Kaynaklari', 14);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanicilar`
--

CREATE TABLE `kullanicilar` (
  `id` int(11) NOT NULL,
  `mail` varchar(70) COLLATE utf8_turkish_ci NOT NULL,
  `sifre` varchar(25) COLLATE utf8_turkish_ci NOT NULL,
  `tc` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `adsoyad` varchar(70) COLLATE utf8_turkish_ci NOT NULL,
  `telefon` varchar(14) COLLATE utf8_turkish_ci NOT NULL,
  `yetki` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `kullanicilar`
--

INSERT INTO `kullanicilar` (`id`, `mail`, `sifre`, `tc`, `adsoyad`, `telefon`, `yetki`) VALUES
(1, 'omeremreelma', '123456', '162805010', 'Ömer Emre Elmali', '05511628184', 1),
(2, 'onurgama@gmail.com', '12345', '', 'Onur Yüksekkaya', '05414259114', 1),
(3, 'yunus@gmail.com', '123456', '123', 'Yunus Aslancan', '05539013507', 1),
(5, 'mehmetaslan@gmail.com', '12345', '12345678911', 'Mehmet Aslan', '53005304123454', 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musteriyorum`
--

CREATE TABLE `musteriyorum` (
  `id` int(11) NOT NULL,
  `yorum` text COLLATE utf8_turkish_ci NOT NULL,
  `musteriid` int(11) NOT NULL,
  `otelid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `musteriyorum`
--

INSERT INTO `musteriyorum` (`id`, `yorum`, `musteriid`, `otelid`) VALUES
(5, 'Hayatimin geçirdigim en güzel tatildi ,   otel personeli oldukça ilgiliydi.', 4, 11),
(6, 'Ilgisiz  calisanlara sahip bir otel', 4, 7);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `oteller`
--

CREATE TABLE `oteller` (
  `id` int(11) NOT NULL,
  `adi` varchar(60) COLLATE utf8_turkish_ci NOT NULL,
  `telefon` varchar(13) COLLATE utf8_turkish_ci NOT NULL,
  `mail` varchar(70) COLLATE utf8_turkish_ci NOT NULL,
  `yildizsayi` int(11) NOT NULL,
  `odasayi` int(11) NOT NULL,
  `puan` int(11) NOT NULL,
  `adres` text COLLATE utf8_turkish_ci NOT NULL,
  `sehir` varchar(70) COLLATE utf8_turkish_ci NOT NULL,
  `ilce` varchar(70) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `oteller`
--

INSERT INTO `oteller` (`id`, `adi`, `telefon`, `mail`, `yildizsayi`, `odasayi`, `puan`, `adres`, `sehir`, `ilce`) VALUES
(7, 'Bornova Plaza', '0212 312 2144', 'iletisim@bornovaplaza.net', 4, 45, 83, 'Bornova Kazim Dirik Mah. Ataturk Cad . no; 15', 'Izmir', 'Bornova'),
(8, 'Anemon', '0232 446 36 5', 'anemon@izmir.com', 3, 60, 71, 'Oguzlar Mahallesi, Mürselpasa Blv. No:40', 'izmir', 'Konak'),
(9, 'Extenso Hotel', '(0232) 204 09', 'extenso@insankaynaklari.com', 4, 35, 88, 'Gazi Mahallesi, Akçay Cd. No:218', 'izmi', 'Gaziemir'),
(10, 'Four Points By Sheraton', '(0232) 344 41', 'pointizmir@hotels.com', 5, 50, 89, 'Çinarli Mahallesi, Cinaralti Avenue, Ankara Cd. No: 17/A', 'izmir', 'Konak'),
(11, 'Swissotel Büyük Efes Izmir', '(0232) 414 00', 'iletisim@swisssotel.com', 5, 70, 96, 'Ismet Kaptan Mahallesi, Gazi Osman Pasa Blv. No 1', 'izmir', 'Alsancak'),
(14, 'Holiday Inn Istanbul', '(0216) 339 11', 'iletisim@holiday.com', 3, 50, 86, 'Hasanpasa Mahallesi, Egitim Mahallesi, Poyraz Sk. No:6,', 'Istanbul', 'Kadiköy');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `calisan`
--
ALTER TABLE `calisan`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kullanicilar`
--
ALTER TABLE `kullanicilar`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `musteriyorum`
--
ALTER TABLE `musteriyorum`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `oteller`
--
ALTER TABLE `oteller`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `calisan`
--
ALTER TABLE `calisan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Tablo için AUTO_INCREMENT değeri `kullanicilar`
--
ALTER TABLE `kullanicilar`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Tablo için AUTO_INCREMENT değeri `musteriyorum`
--
ALTER TABLE `musteriyorum`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Tablo için AUTO_INCREMENT değeri `oteller`
--
ALTER TABLE `oteller`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
