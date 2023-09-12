Bokeh Studio ist in viele kleine Registerkarten unterteilt. Ich werde die Dokumentation in Teile aufteilen, die zu diesen Registerkarten passen, und ein paar Dinge separat behandeln. 

Wichtige Hinweise:
- Es gibt eine Menge Beispielmaterialien in "Examples" und Beispiel-Prefabs in "Prefabs", beide im Ordner Resources.
- Sie benötigen ein Tiefenlicht, um dies in VRChat zu verwenden, oder Echtzeit-Beleuchtung in der Welt. Andernfalls wird die Tiefeninformation nicht an den Shader weitergeleitet (aber Sie können sie im "Always"-Modus ohne verwenden). Dies ist bereits in den Prefabs enthalten und existiert im Prefab-Ordner selbst.
- Ich schlage vor, den Modus "Hohe Qualität" für die Produktion zu verwenden (in Ihren Fotos oder ähnlichem) und die niedrigere Qualität zum Testen beizubehalten. Auf diese Weise können Sie einen schnelleren Arbeitsablauf erreichen und verbrauchen dabei weniger Ressourcen.
- Die Verwendung in Echtzeitsituationen wird nicht empfohlen, eher für Fotos, da sie sehr ressourcenintensiv ist (sie kann aber in Echtzeit verwendet werden, wenn Sie möchten).

Getrennte Dinge:
- Modus "Hohe Qualität": Für den tatsächlichen Gebrauch, zum Testen deaktivieren. Die Kompilierung dauert ein paar Sekunden und die Leistung ist schlechter, aber es sieht viel, viel besser aus. Verwendet mehr Samples, um die Formen detaillierter zu formen, was besonders bei größeren Bokeh-Größen auffällig ist.
- Sprache: Dies ändert die Sprache der Benutzeroberfläche und speichert pro Material.

Reiseführer Karte:
- Hilfslinienkarte: Dies ist die Form, die für die Größe des Bokehs verwendet wird. Helle Werte im Bild (rot, grün, blau, weiß) führen dazu, dass die Form auf jeden Unschärfepunkt gezeichnet wird, und dunkle Werte im Bild (schwarz, grau) führen dazu, dass dieser Teil des Bildes von der Form ausgeschlossen wird. Sie können natürlich auch dazwischen kombinieren, um "weichere" Formen mit auslaufenden Kanten zu erzeugen.
- Bokeh-Formen zufällig erstellen: Ermöglicht die Verwendung von Spritesheets mit verschiedenen Maps, um verschiedene Bokeh-Formen über den Bildschirm zu ziehen.
- Stil zufällig wählen: Sie können die Formen entweder im Laufe der Zeit ändern oder je nachdem, welcher Punkt in ein Bokeh verschwimmt. Im ersten Fall sind die Bokehs immer gleichmäßig geformt und ändern sich im Laufe der Zeit. Sie können beide Varianten auch kombinieren.
- Zufallsgeschwindigkeit: Wie schnell sich die Formen ändern, wenn die Zeit als Faktor berücksichtigt wird.
- Variation zufällig festlegen: Wie viel Variation zwischen den Regionen auf dem Bildschirm als Faktor berücksichtigt wird (z. B. haben höhere Werte mehr Formen in kleineren Bereichen).
- Zufällige X-Reihen: Wie viele Reihen von Formen sind im Spritesheet (z.B. für ein 4x4 Spritesheet wäre dies 4).
- Zufällige Y-Zeilen: Wie viele Spalten der Formen im Spritesheet sind (z.B. für ein 4x4 Spritesheet wäre dies 4).

Fokal-Einstellungen:
- Fokal-Modus: Es gibt drei Modi: Manuell, Automatisch und Immer.
- Bei der manuellen Einstellung können Sie einen bestimmten Tiefenwert wählen, der mit der aktuellen Tiefe an jedem Pixel verglichen wird.
- Automatisch verwendet die angegebenen Koordinaten (standardmäßig die Mitte des Bildschirms), um die Tiefe dieses Pixels zu ermitteln und vergleicht sie dann mit der aktuellen Tiefe an jedem anderen Pixel.
- Mit Immer wird jeder Teil des Bildschirms gleichmäßig weichgezeichnet, wie bei einem herkömmlichen Weichzeichner.

Kamera-Steuerung:
- Größe der Form: Legt fest, wie groß der Bereich ist, der bei der Unschärfe jeder Abgriffsposition berücksichtigt wird (z. B. führt ein höherer Wert zu einem größeren Abstand zwischen jedem Formabtastschritt und jedem Punkt auf der Form).
- Bokeh-Stärke: Legt fest, wie stark sich die Tiefe auf die Größe jeder Form an jeder getippten Position auswirkt (z. B. führt ein höherer Wert zu einem größeren Unterschied zwischen der Größe der Formen in verschiedenen Tiefen).
- Temperatur: Wie stark jeder Abgriff und seine berücksichtigten Faktoren bei der Unschärfe sind (z. B. führt eine höhere Zahl zu kleineren Formen, da die Werte stärker "normalisiert" sind. (sorry, das ist verwirrend (ich werde es eines Tages neu schreiben)).

Zusätzliche Faktoren:
- Es gibt zwei zusätzliche Faktoren: "Nahbereichstiefe" und "Luma". Die Nahbereichstiefe hilft, starke Unschärfe zu verhindern, wenn sich etwas sehr nah an der Kamera befindet, aber unscharf ist. Luma sorgt für eine stärkere Unschärfe in helleren Bereichen des Bildschirms, was für einen "Glüheffekt" genutzt werden kann.
- Die Einflusswerte für jeden Wert steuern, wie stark sich die Größe der Bokeh-Formen dadurch ändert.
- "Ende" für Nahaufnahme-Tiefe ändert den Abstand, der als "nah" gilt, und "Minimum" für Luma ändert die Mindesthelligkeit, die als "hell" gilt.

Animationseinstellungen:
- Mit diesen Optionen können Sie entweder alle Formen auf dem Bildschirm gleichzeitig ändern oder jede einzelne auf der Grundlage der Tippposition unterschiedlich ändern.
- Mit "Animationsvariation" können Sie festlegen, wie stark verschiedene Bereiche des Bildschirms bei der Änderung der Formen berücksichtigt werden (z. B. führen höhere Werte zu mehr Variation in der Animation zwischen den Formen).
- Mit "Rotation Bokehs" werden die Formen gedreht. "Bokehs skalieren" verkleinert und vergrößert die Formen.
- Lokal" bedeutet, dass jedes Bokeh anders animiert wird (z. B. unter Verwendung der oben genannten Eigenschaft "Animationsvariation"). "Universal" bedeutet, dass alle Bokehs auf die gleiche Weise animiert werden.

Saubere Ränder:
- Sorgt für einen sanfteren Übergang zwischen den Unschärfen um die gewünschte Schärfentiefe. Wenn diese Option aktiviert ist, werden nicht nur die Motive unscharf, sondern auch der Bereich um sie herum, da er sanft in eine Unschärfe übergeht. So wird verhindert, dass das Motiv selbst in den unscharfen Mustern zu sehen ist.
- Überblendungsradius: Wie groß der Bereich ist, der für den Übergang von unscharf zu unscharf berücksichtigt wird.
- CoC-Radius: Wie groß der Bereich ist, der beim Antippen des Unschärfezentrums berücksichtigt wird.

Beleuchtungseinstellungen:
- Bokehs akzentuieren: Betont die Lebendigkeit der erschlossenen Bereiche.
- Bokehs belichten: Macht die Bokehs heller.
- Tonemap-Bokehs: Wendet einen Tonemapping-Filter auf die Bokehs an (z. B. Farbkorrektur im Kino).
- Farbmodus: Wendet je nach ausgewähltem Modus einen Farbfilter entweder auf die Bokeh-Formen oder den Bildschirm an.
- HSV-Steuerungen: Ermöglicht die Bearbeitung des Farbtons, der Sättigung oder des Werts der Bokeh-Formen oder des Bildschirms, je nach ausgewähltem Modus "Tap Based".

Technische Einstellungen:
- Cull-Abstand: Wie weit von der Mitte des Objekts entfernt wird das Bokeh nicht mehr gerendert.
- Dithering: Verhindert, dass die einzelnen Punkte einer Form sichtbar werden, indem die Position jedes Punktes leicht zufällig gewählt wird.
- Maximaler Durchmesser: Die maximale Größe einer Bokeh-Form.
- Ferne Ebene: Die entfernte Ebene der Kamera. Sie wird verwendet, um den Abstand der Bokeh-Formen zu bestimmen.
- Nur VRC-Kamera: Nur in VRChat Fotos und Kameras rendern. Wenn "VRC-Kamera-Vorschau" ausgewählt ist, wird es auch in der Kamera-Vorschau gerendert.