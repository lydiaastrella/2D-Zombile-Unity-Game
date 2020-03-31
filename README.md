# IF3210-2020-Unity-13517019

# Deskripsi Aplikasi
Aplikasi permainan wave survival 2D desktop. Permainan ini dapat dimainkan oleh satu orang pemain. Permainan ini terdiri dari 3 ronde. Objektif permainan adalah membunuh semua musuh yang muncul dalam 3 ronde. Untuk mengalahkan musuh, pemain memiliki macam-macam kontrol gerak terhadap avatar pemain (berjalan ke kiri, berjalan ke kanan, lompat, merangkak) dan kontrol menyerang dengan menembakkan peluru. Pemain memilih health point sebesar 100 dan kalah bila health point mencapai 0 sebelum ronde 3 selesai. 

# Cara kerja, terutama mengenai pemenuhan spesifikasi aplikasi
1. Terdapat sebuah karakter pemain yang dapat berjalan dan melompat dengan menggunakan script movement. Karakter pemain dapat menembakkan senjata dengan script weapon. Karakter pemain mengikuti hukum fisika dengan menggunakan circle collider 2D untuk bagian badan, box collider 2D untuk bagian kepala, serta rigidbody2D agar memiliki efek gravitasi.
2. Karakter dapat berjalan ke kanan dengan menekan tombol d/right, ke kiri dengan menekan tombol a/left, lompat dengan menekan tombol w/space, crouch dengan menekan tombol s/down, serta menembak dengan left click mouse.
3. Terdapat sound effect pada saat akrakter menembak dengan menggunakan audiosource pada player.
4. Pergerakan kamera diatur agar center camera (secara horizontal saja) sesuai dengan posisi pemain. Kecuali ketika pemain mendekati batas map, kamera akan diam agar tidak menembus batas map.
5. Terdapat animasi pergerakan karakter saat berjalan, lompat, merangkak, dan menembak dengan menggunakan animator.
6. Zombie digenerate dengan Instantiate. Jika pemain bersentuhan dengan zombie, maka darah pemain berkurang.
7. Karakter memiliki max health 100 dan kalah ketika health 0.
8. Map didesain.
9. Score yang didapat ketika membunuh zombie ditampilkan dan disimpan.
10. Score disimpan dalam basis data online. Saat permainan selesai menang/kalah, pemain diminta memasukkan username agar scoreboard pada basis data dapat diupdate.
11. Terdapat scene permainan dan main menu. Pada scene main menu dapat menammpilkan scoreboard.
12. Terdapat setting audio enable/disable.
13. Asset yang digunakan dalam bentuk 2D.
14. Permainan dikhususkan sebagai aplikasi desktop.

# Library yang digunakan dan justifikasi penggunaannya
Aplikasi permainan hanya menggunakan library bawaan Unity.

# Screenshot aplikasi
## Main Menu

## Di Dalam Permainan

## Permainan Selesai

## Scoreboard
