IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
newline db 13, 10, '$'
introMsg db "Welcome to the roman numeral converter!$"
selectMsg db "Please select mode:", 10, 13, "Decimal number to Roman numeral - 1", 10, 13, "Roman numeral to Decimal number - 2", 10, 13, "Game - 3$"
wrongInputMsg db "Wrong input! Please enter again$"
exitMsg db "Closing converter$"
;all_numerals: .asciiz "IVXLCDMivxlcdm"
;all_values:   .byte 1, 5, 10, 50, 100, 500, 1000, 1, 5, 10, 50, 100, 500, 1000
; --------------------------
CODESEG

proc SelectMode
	mov dx, offset selectMsg
	mov ah, 9
	int 21h
	
	; newline
	mov dx, offset newline
	mov ah, 9h
	int 21h
	
InputLoop:
	; Input
	mov ah, 1h
	int 21h
	
	sub al, 30h ; convert from ascii to number
	
	cmp al, 1
	je NumToRoman
	
	cmp al, 2
	je RomanToNum
	
	cmp al, 3
	je Game
	
	; TODO: Add "exit" input check and jump to exit
	; Maybe do 4 to exit instead of "exit" because of 1 char input
	; je ExitConverter
	
	; newline
	mov dx, offset newline
	mov ah, 9h
	int 21h
	
	; Wrong input entered - not 1, 2, 3, exit
	mov dx, offset wrongInputMsg
	mov ah, 9
	int 21h
	
	; newline
	mov dx, offset newline
	mov ah, 9h
	int 21h
	
	jmp InputLoop ; Get another input
	
	ret
endp SelectMode


proc NumToRoman
	
	
	ret
endp NumToRoman


proc RomanToNum
	
	
	ret
endp RomanToNum


proc Game
	
	
	ret
endp Game

Msg equ [bp + 4]
proc PrintMsg
	push bp
	mov bp, sp
	
	; Prints the message
	mov dx, offset Msg
	mov ah, 9
	int 21h
	
	; newline
	mov dx, offset newline
	mov ah, 9h
	int 21h
	
	pop bp
	ret 2
endp PrintMsg


start:
	mov ax, @data
	mov ds, ax
; --------------------------
	push introMsg
	call PrintMsg
	
	call SelectMode
	
ExitConverter:
	; newline
	mov dx, offset newline
	mov ah, 9h
	int 21h
	
	mov dx, offset exitMsg
	mov ah, 9
	int 21h
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


