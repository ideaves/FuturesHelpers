# FuturesHelpers

# The purpose for this as a separate coded project is to allow anybody using .NET and C# to be able to instantly
# untangle the constantly-moving world of Futures contracts, and treat them much like normal securities like bonds
# and stocks. Futures contracts expire on set calendar dates, based on product specifications from the exchanges 
# that facilitate trade in them. They expire and disappear, and become non-tradeable sometimes prior to the actual 
# expiration date. 

# Expiration, notice, and delivery dates for Futures contracts all impact the meaning imputed from traded prices, 
# applying to the underlying commodity, or security, or cash-settled quantity. Even if only naive use of futures 
# pricing is needed, like requesting the front two contracts, even without knowing their expiration dates, you 
# would need to know when to change the futures symbol to get the price quote, and what to change them to.

# Presently this only tracks six mostly financial futures contract series, which I have implemented for my work.
# It should be straight forward to add to the product specifications for your own bespoke work, building on this
# as a starting point.  Or, you can reach out, and I'd be happy at my leisure to add them.  Or, to expedite any
# additional product specifications, I'd be happy to do it for a nominal fee, TBD.

# Currently supports ES, EC, GC, US, BTC, NQ
