;;; SpeedTest2.asm
;;; D. Thiebaut
;;;
;;; Computes an optimized version of this code:
;;;
;;;   int a=0, b=2, c=3
;;;   for ( int i=0; i<noIterations; i++ )
;;;            a += b*2 + c - i;
;;;
;;; Requires the 231Lib.asm library to compile.  
;;; To assemble, link, and run:
;;;
;;; nasm -f elf SpeedTest2.asm
;;; nasm -f elf 231Lib.asm 
;;; ld -melf_i386 -o SpeedTest2 SpeedTest2.o 231Lib.o
;;; time ./SpeedTest2
;;;
extern  _printDec
extern  _println

        
        section .data
a       dd      0
b       dd      2
c       dd      3
iter    dd      100000000
i       dd      0

        section .text
        global  _start
_start: 

        mov     edx, 0          ; use edx as i
        mov     ebx, dword[b]   ; use ebx as 2*b + c
        add     ebx, ebx
        add     ebx, dword[c]
        mov     eax, 0          ; use eax as a
        mov     ecx, dword[iter]; ecx is loop counter
        
for:    add     eax, ebx        ; a += b*2 + c
        sub     eax, edx        ; a += -i
        inc     edx             ; i++
        loop    for
        
endfor: 
        mov     dword[a], eax
        call    _printDec
        call    _println
        
;;; exit
        mov     eax, 1
        mov     ebx, 0
        int     0x80