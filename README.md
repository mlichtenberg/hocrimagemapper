This simple app provides a way to visualize hOCR output.

Per Wikipedia: "hOCR is an open standard of data representation for 
formatted text obtained from optical character recognition (OCR). 
The definition encodes text, style, layout information, recognition 
confidence metrics and other information using Extensible Markup 
Language (XML) in form of Hypertext Markup Language (HTML) or XHTML."
(http://en.wikipedia.org/wiki/HOCR)

hOCR is produced by the Tesseract, Cuneiform, and OCRopus OCR
software.

This application has been implemented as a simple WinForms application 
(yeah, I know, but it was quick) written in C#.

When using the application, the text contained in an hOCR file is 
loaded alongside the image that is the source of the OCR output.  
Hovering over a word in the text highlights the word in the image.  
Clicking a word in the text displays the coordinates for the bounding 
box used to highlight the word.  (This bounding box is extracted from
the hOCR output).  The coordinates are displayed as two pairs of X-Y 
coordinates that represent the upper right and lower left corners of 
the bounding box.

