A
Selv uten join funksjonen så virket programet som det skulle. Jeg satte trådene som background tråder så fikk jeg se en tydelig forkjell, programet fullfører uten at dronene er ferdige.

B
I denne oppgaven ble det implementert Task og TaskCompletionSource for å signalisere eksplisitt når en drone er ferdig eller feiler.
hver drone fullfører sin Task og Task.WhenAll brukes for å vente på alle uten å blokkere hovedtråden. Sammenlignet med Thread og Join gir dette bedre kontroll og tydligere feilhåndtering, men er mer komplisert å implementere.

C
Ved å bruke Async/await blir programet mye mer lesbart, task fullføres når metoden er ferdig og exceptions propagerer direkte til Task.Whenall uten behov for taskCompletionSource. Dettte fjerner mye boilerplate kode og gjør løsningen enkelere å vedlikeholde samtidig som funksjonalitet blir den samme.

D

